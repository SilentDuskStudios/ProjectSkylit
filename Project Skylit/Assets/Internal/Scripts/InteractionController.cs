using UnityEngine;

public class InteractionController : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    public Interactor interactor;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Update() {

        if (Input.GetKeyDown(KeyCode.F))
            interactor.Interacting();

    }

    #endregion

}