using UnityEngine;

public class SurvivorController : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    public WeaponController weaponController;

    public InteractionController interactionController;

    public InventoryController inventoryController;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void EnableControllers() {

        weaponController.enabled = true;
        interactionController.enabled = true;
        inventoryController.enabled = true;
    }

    public void DisableControllers() {

        weaponController.enabled = false;
        interactionController.enabled = false;
        inventoryController.enabled = false;
    }

    #endregion

}