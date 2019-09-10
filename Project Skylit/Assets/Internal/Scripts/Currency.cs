using UnityEngine;

public class Currency : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    public static Currency currency;

    private int currentCurrency;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Awake() {

        if (currency == null) {
            currency = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    private void Start() {

        CanvasManager.canvasManager.UpdateCurrencyPanel(currentCurrency);
    }

    public void Add(int amount) {

        currentCurrency += amount;
    }

    public void Subtract(int amount) {

        currentCurrency -= amount;
    }

    public int GetCurrentCurrency() {

        return currentCurrency;
    }

    #endregion
}