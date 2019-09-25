using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarricadePanel : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Slider[] barricadeHealthBarSliders;

    [SerializeField]
    private TMP_Text healthBarPercentageText;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void UpdateBarricadeHealthBar(int barricadeID, int currentHealth, int maxHealth) {

        barricadeHealthBarSliders[barricadeID].value = (float)currentHealth / (float)maxHealth;


        //float currentPercentage = (float)currentHealth / (float)maxHealth;
        //healthBarPercentageText.text = currentPercentage.ToString() + "%";
    }

    public void EnableBarricadePanel() {

        this.gameObject.SetActive(true);
    }

    public void DisableBarricadePanel() {

        this.gameObject.SetActive(false);
    }

    #endregion

}