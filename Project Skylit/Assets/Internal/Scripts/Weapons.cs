using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Weapons : MonoBehaviour { 

    #region " - - - - - - Fields - - - - - - "

    private List<Weapon> weaponList;
    private int amountOfWeapons;

    public Weapon activeWeapon;

    CanvasManager canvasManager;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private FirstPersonAIO firstPersonAIO;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Start() {

        weaponList = new List<Weapon>();

        foreach (Transform weapon in this.gameObject.transform)
            weaponList.Add(weapon.GetComponent<Weapon>());

        amountOfWeapons = weaponList.Count;
        activeWeapon = weaponList.First();

        CanvasManager.canvasManager.UpdateWeaponPanel(activeWeapon.name, activeWeapon.currentClip, activeWeapon.currentReserveClip,
            activeWeapon.image);
    }

    public void CycleNextWeapon() {

        if (activeWeapon.IsReloading())
            return;

        activeWeapon.gameObject.SetActive(false);

        int currentWeaponListIndex = weaponList.IndexOf(activeWeapon);

        //If the survivor is holding their last weapon in the list before cycling next.
        if (currentWeaponListIndex == weaponList.Count - 1)
            currentWeaponListIndex = 0;
        else
            currentWeaponListIndex++;

        activeWeapon = weaponList[currentWeaponListIndex].GetComponent<Weapon>();
        activeWeapon.gameObject.SetActive(true);

        CanvasManager.canvasManager.UpdateWeaponPanel(activeWeapon.name, activeWeapon.currentClip, activeWeapon.currentReserveClip,
            activeWeapon.image);
    }

    public void CyclePreviousWeapon() {

        if (activeWeapon.IsReloading())
            return;

        activeWeapon.gameObject.SetActive(false);

        int currentWeaponListIndex = weaponList.IndexOf(activeWeapon);

        //If the survivor is holding their first weapon in the list before cycling back.
        if (currentWeaponListIndex == 0)
            currentWeaponListIndex = weaponList.Count - 1;
        else
            currentWeaponListIndex--;

        activeWeapon = weaponList[currentWeaponListIndex].GetComponent<Weapon>();
        activeWeapon.gameObject.SetActive(true);

        CanvasManager.canvasManager.UpdateWeaponPanel(activeWeapon.name, activeWeapon.currentClip, activeWeapon.currentReserveClip,
            activeWeapon.image);
    }

    
    public void AimDownSight(bool flag) {

        //flag parameter determines whether the survivor is aiming down the sight or not.
        //TODO: Lower mouse sensitivity 
        if (flag) {
            camera.fieldOfView = 50f;
            firstPersonAIO.mouseSensitivity = 1.5f;
            this.gameObject.transform.localPosition = new Vector3(0, -0.5f, 1);
        }

        else {
            camera.fieldOfView = 60f;
            firstPersonAIO.mouseSensitivity = 4f;
            this.gameObject.transform.localPosition = new Vector3(-1, -0.8f, 2.2f);
        }
    }

    #endregion //Methods
}