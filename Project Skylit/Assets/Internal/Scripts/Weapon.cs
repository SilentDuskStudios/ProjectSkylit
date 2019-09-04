using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;

public class Weapon : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private int damage;

    [SerializeField]
    private int maxCurrentClip, maxReserveClip, currentClip, currentReserveClip;

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

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Start() {

        currentClip = maxCurrentClip;
        currentReserveClip = maxReserveClip;

        //rayBulletStart = new Ray(nozzle.position, nozzle.forward * range);
        rayBulletStart = new Ray(Camera.main.gameObject.transform.position, Camera.main.gameObject.transform.forward * range);
    }

    //TODO: What if this turns to be a 
    //TODO: <--- if you see this by itself, read the method and fix up comments...?
    public void Fire() {

        if (currentClip > 0)
            Shoot();
        else {
            //Inform survivor that he has no ammo to shoot.
        }
    }

    public void CycleNextWeapon() {


    }

    private void Shoot() {

        if (Physics.Raycast(survivorView.transform.position, survivorView.transform.forward, out RaycastHit hit, range, layerMask)) {

            GameObject bullelHole = Instantiate(decal.gameObject, hit.point, hit.transform.rotation);

            bullelHole.transform.SetParent(hit.transform);
            if (hit.transform.gameObject.GetComponent<Beast>()) {

                hit.transform.gameObject.GetComponent<Beast>().TakeDamage(damage);


            }
        }
        //Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * range, Color.red, 1f);

        currentClip--;

        if (currentClip < 0)
            currentClip = 0;
 
    }

    public void Reload() {

        if (CanReload()) {

            while(currentClip != maxCurrentClip) {

                if (currentReserveClip < 1)
                    return;

                currentClip++;
                currentReserveClip--;

            }
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