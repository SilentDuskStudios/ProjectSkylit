using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour { 

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Weapon weapon;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Start() {
        
    }

    private void Update() {

        //TODO: if check what type of weapon, gun or meele?
        if (Input.GetButtonDown("Fire1"))
            weapon.Fire();


        if (Input.GetKeyDown(KeyCode.R)) {
            weapon.Reload();
        }
            
        //if (Input.GetButtonDown("Reload"))
        //    weapon.Reload();
        
        //TODO: Add the following inputs...
        //      Reload, NextWeapon, PreviousWeapon, Melee (hit with weapon(weapon's melee damage will be sent)).



    }

    #endregion //Methods
}