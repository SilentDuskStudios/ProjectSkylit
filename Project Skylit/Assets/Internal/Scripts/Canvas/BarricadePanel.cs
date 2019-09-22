using UnityEngine;
using UnityEngine.UI;

public class BarricadePanel : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Slider[] barricadeHealthBarSliders;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void UpdateBarricadeHealthBar(int barricadeID, int currentHealth, int maxHealth) {

        barricadeHealthBarSliders[barricadeID].value = (float)currentHealth / (float)maxHealth;
    }

    public void EnableBarricadePanel() {

        this.gameObject.SetActive(true);
    }

    public void DisableBarricadePanel() {

        this.gameObject.SetActive(false);
    }

    #endregion

}