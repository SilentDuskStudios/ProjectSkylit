using UnityEngine;

public class SkillController : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    public Skills skills;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Update() {

        if (Input.GetKeyDown(KeyCode.T))
            CanvasManager.canvasManager.EnableSkillPanel(skills.skillpoint);
    }

    #endregion

}