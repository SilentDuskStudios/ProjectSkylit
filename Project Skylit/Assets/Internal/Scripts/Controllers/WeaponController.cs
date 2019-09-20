using UnityEngine;

public class WeaponController : MonoBehaviour { 

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Weapons weapons;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Update() {

        //TODO: if check what type of weapon, gun or meele?

        if(weapons.activeWeapon.fireType == FireTypeEnum.semiAutomatic) {

            if (Input.GetButtonDown("Fire1"))
                weapons.activeWeapon.Fire();

        }
        else if(weapons.activeWeapon.fireType == FireTypeEnum.automatic) {

            if (Input.GetButton("Fire1"))
                weapons.activeWeapon.Fire();

        }

        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(weapons.activeWeapon.Reload());

        if (Input.GetKeyDown(KeyCode.E))
            weapons.CycleNextWeapon(); 

        if (Input.GetKeyDown(KeyCode.Q))
            weapons.CyclePreviousWeapon();

        if(Input.GetMouseButtonDown(1))
            weapons.AimDownSight(true);

        if (Input.GetMouseButtonUp(1))
            weapons.AimDownSight(false);
        //Add Meele with weapon. weapon will have varying meele damage

    }

    #endregion //Methods
}