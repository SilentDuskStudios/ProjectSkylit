using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Weapon weapon;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            weapon.Fire();

        //TODO: Add all interactions in here.
        
        //TODO: Add the following inputs...
        //      Reload, NextWeapon, PreviousWeapon, Melee (hit with weapon(weapon's melee damage will be sent)).



    }

    #endregion //Methods
}