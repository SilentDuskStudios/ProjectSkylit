using UnityEngine;
using UnityEngine.UI;

public class ReticlePanel : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Image reticleImage;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void EnableReticlePanel() {

        this.gameObject.SetActive(true);
    }

    public void DisableReticlePanel() {

        this.gameObject.SetActive(false);
    }

    #endregion

}