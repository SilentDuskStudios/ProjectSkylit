using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Weapons : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "

    private List<Weapon> weaponList;
    private int amountOfWeapons;

    public Weapon activeWeapon;

    CanvasManager canvasManager;

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

    #endregion //Methods
}