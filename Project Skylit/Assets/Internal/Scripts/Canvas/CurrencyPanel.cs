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

    #endregion

}