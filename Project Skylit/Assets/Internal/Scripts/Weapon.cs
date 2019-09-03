using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Transform nozzle;

    [SerializeField]
    private float range;

    [SerializeField]
    private int maxCurrentClip, maxReserveClip, currentClip, currentReserveClip;


    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Start() {

        currentClip = maxCurrentClip;
        currentReserveClip = maxReserveClip;

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

    private void Shoot() {

        Debug.DrawRay(nozzle.position, nozzle.forward * range, Color.red, 1f);

        currentClip--;

        if (currentClip < 0)
            currentClip = 0;
        //How to do a real raycast...
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