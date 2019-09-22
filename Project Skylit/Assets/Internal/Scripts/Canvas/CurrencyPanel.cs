using TMPro;
using UnityEngine;

public class CurrencyPanel : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private TMP_Text currencyText;

    #endregion

    #region " - - - - - - Methods - - - - - - "



    public void UpdateCurrencyPanel(int currency) {

        currencyText.text = currency.ToString();
    }

    public void EnableCurrencyPanel() {

        this.gameObject.SetActive(true);
    }

    public void DisableCurrencyPanel() {

        this.gameObject.SetActive(false);
    }

    #endregion

}