using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class InteractionPanel : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private TMP_Text interactionText;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void UpdateInteractionPanel(InteractionTypeEnum interactionType) {

        this.gameObject.SetActive(true);
        interactionText.text = "Press F interact with: " + interactionType;
    }

    public void DisableInteractionPanel() {

        this.gameObject.SetActive(false);
    }

    #endregion

}