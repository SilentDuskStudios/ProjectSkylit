using UnityEngine;

public class InputManager : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private FirstPersonAIO firstPersonAIO;

    [SerializeField]
    private SurvivorController survivorController;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void EnableSurvivorControls() {

        firstPersonAIO.enabled = true;
        survivorController.EnableControllers();
    }

    public void DisableSurvivorControls() {

        firstPersonAIO.enabled = false;
        survivorController.DisableControllers();
    }

    public void EnableCursor() {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void DisableCursor() {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    #endregion

}