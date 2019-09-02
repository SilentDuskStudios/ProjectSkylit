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

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    public void Fire()
    {
        Debug.DrawRay(nozzle.position, nozzle.forward * range, Color.red, 1f);
        //How to do a real raycast...
        
    }

    #endregion //Methods
}