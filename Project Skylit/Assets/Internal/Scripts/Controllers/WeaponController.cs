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
    }

    #endregion //Methods
}