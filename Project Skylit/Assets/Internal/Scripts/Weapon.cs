using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;

public class Weapon : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private int damage;

    public int maxCurrentClip, maxReserveClip, currentClip, currentReserveClip;

    [SerializeField]
    private float range;

    [SerializeField]
    private Transform nozzle;

    //TODO: I want to rename this field.
    Ray rayBulletStart;

    [SerializeField]
    private Camera survivorView;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private DecalProjectorComponent decal;

    [SerializeField]
    private float fireRate;

    public FireType fireType;

    private float fireRateTimer;

    private bool hasShot;

    public Sprite image;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Start() {

        currentClip = maxCurrentClip;
        currentReserveClip = maxReserveClip;

        hasShot = false;
        fireRateTimer = fireRate;
    }

    private void Update() {

        if (hasShot) 
            fireRateTimer += Time.deltaTime;

    }

    public void Fire() {

        hasShot = true;

        if ((currentClip > 0) && (fireRateTimer >= fireRate)) {

            Shoot();
            fireRateTimer = 0f;
            hasShot = false;

        }
        else {
            //Inform survivor that he has no ammo to shoot.
        }
    }

    private void Shoot() {

        rayBulletStart = new Ray(survivorView.transform.position, survivorView.transform.forward * range);
        if (Physics.Raycast(rayBulletStart, out RaycastHit hit, range, layerMask)) {

            Debug.Log(hit.transform.name);

            GameObject bullelHole = Instantiate(decal.gameObject, hit.point, hit.transform.rotation);

            bullelHole.transform.SetParent(hit.transform);
            if (hit.transform.gameObject.GetComponent<Beast>()) {

                hit.transform.gameObject.GetComponent<Beast>().TakeDamage(damage);

            }
        }
        Debug.DrawRay(survivorView.transform.position, survivorView.transform.forward * range, Color.red, 1f);

        currentClip--;

        if (currentClip < 0)
            currentClip = 0;

        CanvasManager.canvasManager.UpdateWeaponPanel(this.gameObject.name, currentClip, currentReserveClip, image);

    }

    public void Reload() {

        if (CanReload()) {

            while(currentClip != maxCurrentClip) {

                if (currentReserveClip < 1)
                    return;

                currentClip++;
                currentReserveClip--;

            }

            CanvasManager.canvasManager.UpdateWeaponPanel(this.gameObject.name, currentClip, currentReserveClip,image);
        }
        else {
            Debug.Log("You cannot reload!");
        }

    }

    private bool CanReload() {

        return ((currentClip != maxCurrentClip) && (currentReserveClip > 0));

    }

    #endregion //Methods
}