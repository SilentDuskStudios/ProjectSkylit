using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;

public class Turret : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private int damage;

    [SerializeField]
    private float range;

    [SerializeField]
    private int currentClip;

    [SerializeField]
    private int maxCurrentClip;

    [SerializeField]
    private Transform rotatableHead;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private TurretDetection turretDetection;

    [SerializeField]
    private float fireRate;

    private float fireRateTimer;

    private bool hasShot;

    [SerializeField]
    private Transform muzzle;

    [SerializeField]
    private DecalProjectorComponent decal;

    #endregion

    #region " - - - - - - Methods - - - - - - "


    private void Update() {

        if (hasShot)
            fireRateTimer += Time.deltaTime;

        if (turretDetection.HasTarget) {

            if (turretDetection.Target != null) {
                AimAtTarget();
                Shoot();
            }
            else
                turretDetection.HasTarget = false;
        }
    }

    private void Shoot() {

        hasShot = true;

        if(HasAmmo() && fireRateTimer >= fireRate) {

            hasShot = false;
            fireRateTimer = 0f;
            currentClip--;

            RaycastShoot();
        }
    }

    private void RaycastShoot() {

        Debug.DrawRay(muzzle.position, muzzle.forward * range, Color.green);

        Ray ray = new Ray(muzzle.position, muzzle.forward * range);
        if(Physics.Raycast(ray, out RaycastHit hit, range)) {

            GameObject bulletHole = Instantiate(decal.gameObject, hit.point, hit.transform.rotation);

            bulletHole.transform.SetParent(hit.transform);

            if (hit.transform.GetComponent<Beast>())
                hit.transform.GetComponent<Beast>().TakeDamage(damage);
        }
    }

    private bool HasAmmo() {

        return currentClip > 0;
    }

    private void AimAtTarget() {

        float rotationIncrement = rotationSpeed * Time.deltaTime;
        Debug.DrawRay(rotatableHead.transform.position, rotatableHead.transform.forward * 30f, Color.red);

        //Allows the turret to look at a target with a slight delay.
        Vector3 direction = turretDetection.Target.position - rotatableHead.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        //Forces turret to rotate on the Y axis.
        targetRotation.x = 0f;
        targetRotation.z = 0f;

        rotatableHead.rotation = Quaternion.Slerp(rotatableHead.rotation, targetRotation, rotationIncrement);
    }

    #endregion

}