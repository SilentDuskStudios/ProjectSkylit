using System.Collections;
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
    private Transform muzzle;

    //TODO: I want to rename this field.
    Ray rayBulletStart;

    [SerializeField]
    private Camera survivorCamera;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private DecalProjectorComponent decal;

    [SerializeField]
    private float fireRate;

    public FireTypeEnum fireType;

    private float fireRateTimer;

    private bool hasShot;

    public Sprite image;

    private bool reloading;

    [SerializeField]
    private float reloadTime;

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

    private void Shoot() {

        //TODO: rename the ray?
        rayBulletStart = new Ray(survivorCamera.transform.position, survivorCamera.transform.forward * range);

        if (Physics.Raycast(rayBulletStart, out RaycastHit hit, range, layerMask)) {

            GameObject bullelHole = Instantiate(decal.gameObject, hit.point, hit.transform.rotation);

            bullelHole.transform.SetParent(hit.transform);
            if (hit.transform.gameObject.GetComponent<Beast>()) {

                hit.transform.gameObject.GetComponent<Beast>().TakeDamage(damage);

            }
        }
        Debug.DrawRay(survivorCamera.transform.position, survivorCamera.transform.forward * range, Color.red, 1f);

        currentClip--;

        if (currentClip < 0)
            currentClip = 0;

        CanvasManager.canvasManager.UpdateWeaponPanel(this.gameObject.name, currentClip, currentReserveClip, image);

    }

    public void Fire() {

        if (reloading)
            return;

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

    public IEnumerator Reload() {

        if ((CanReload()) && (!reloading)) {

            reloading = true;

            CanvasManager.canvasManager.UpdateWeaponPanel(reloadTime);
            yield return new WaitForSeconds(reloadTime);

            while (currentClip != maxCurrentClip) {

                if (currentReserveClip < 1)
                    break;

                currentClip++;
                currentReserveClip--;
            }

            CanvasManager.canvasManager.UpdateWeaponPanel(this.gameObject.name, currentClip, currentReserveClip, image);

            reloading = false;
        }
        else {
            //TODO: Inform survivor that they cannot reload for reason {full clip OR no more ammo}
        }

    }

    private bool CanReload() {

        return ((currentClip != maxCurrentClip) && (currentReserveClip > 0));

    }

    public bool IsReloading() {

        if (reloading)
            return true;
        else
            return false;
    }

    #endregion //Methods
}