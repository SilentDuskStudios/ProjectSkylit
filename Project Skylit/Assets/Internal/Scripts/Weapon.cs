using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;

public class Weapon : Item {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private int totalDamage;

    [SerializeField]
    private int baseDamage;

    public int maxCurrentClip, maxReserveClip, currentClip, currentReserveClip;

    [SerializeField]
    private float range;

    [SerializeField]
    private Transform muzzle;

    //TODO: I want to rename this field.
    Ray rayBulletStart;

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

    [SerializeField]
    private AudioClip bulletFireSFX;

    private AudioSource audioSource;

    private Weapons weapons;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Start() {

        currentClip = maxCurrentClip;
        currentReserveClip = maxReserveClip;

        hasShot = false;
        fireRateTimer = fireRate;

        weapons = this.gameObject.transform.parent.GetComponent<Weapons>();


        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update() {

        fireRateTimer += Time.deltaTime;

    }

    private void Shoot() {

        //TODO: rename the ray?
        rayBulletStart = new Ray(weapons.survivorCamera.transform.position, weapons.survivorCamera.transform.forward * range);

        if (Physics.Raycast(rayBulletStart, out RaycastHit hit, range, layerMask)) {

            GameObject bullelHole = Instantiate(decal.gameObject, hit.point, hit.transform.rotation);

            bullelHole.transform.SetParent(hit.transform);
            if (hit.transform.gameObject.GetComponent<Beast>()) {

                //TODO: Add damage skill modifier.
                //TODO: To do this, instead of checking reference multiple times, each time the survivor increases a skill, have the WeaponController
                //      update all the weapons damage instead.
                hit.transform.gameObject.GetComponent<Beast>().TakeDamage(totalDamage);

            }
        }
        Debug.DrawRay(weapons.survivorCamera.transform.position, weapons.survivorCamera.transform.forward * range, Color.red, 1f);

        audioSource.PlayOneShot(bulletFireSFX);


        currentClip--;

        if (currentClip < 0)
            currentClip = 0;

        CanvasManager.canvasManager.UpdateWeaponPanel(this.gameObject.name, currentClip, currentReserveClip, image);

    }

    public void Fire() {

        if (reloading)
            return;

        if ((HasAmmo()) && (fireRateTimer >= fireRate)) {

            //Change this to Raycast() similar to Turrets implementation.
            Shoot();
            fireRateTimer = 0f;

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

    private bool HasAmmo() {

        return currentClip > 0;
    }

    //TODO: Include damage modifiers from other things such as attachments?
    public void UpdateDamage(float damageModifier) {

        totalDamage = (int)Math.Ceiling(((float)baseDamage * damageModifier));
    }

    #endregion
}