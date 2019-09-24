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

    //TODO: Have all the xPanel (i.e CurrencyPanel, WeaponPanel, etc extend from base Panel). So that you don't need
    //to repeat this enable/disablepanel stuff. You can just simply move that to a base class.
    public void EnableCurrencyPanel() {

        this.gameObject.SetActive(true);
    }

    public void DisableCurrencyPanel() {

        this.gameObject.SetActive(false);
    }

    #endregion

}