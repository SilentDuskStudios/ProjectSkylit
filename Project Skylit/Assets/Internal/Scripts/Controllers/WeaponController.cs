using UnityEngine;

public class WeaponController : MonoBehaviour { 

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Weapons weapons;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Update() {

        //TODO: if check what type of weapon, gun or meele?
        if (Input.GetButtonDown("Fire1"))
            weapons.activeWeapon.Fire();

        if (Input.GetKeyDown(KeyCode.R)) {
            weapons.activeWeapon.Reload();
        }

        if (Input.GetKeyDown(KeyCode.E))
            weapons.CycleNextWeapon();

        if (Input.GetKeyDown(KeyCode.Q))
            weapons.CyclePreviousWeapon();

        
        
        //TODO: Add the following inputs...
        //      Reload, NextWeapon, PreviousWeapon, Melee (hit with weapon(weapon's melee damage will be sent)).



    }

    #endregion //Methods
}