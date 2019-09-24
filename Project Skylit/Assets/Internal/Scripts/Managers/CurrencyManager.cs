using UnityEngine;

//TODO: Have all xManagers inherit from GameManager?
public class CurrencyManager : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    private int currentCurrency;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Start() {

        CanvasManager.canvasManager.UpdateCurrencyPanel(currentCurrency);
    }

    public void Add(int amount) {

        currentCurrency += amount;
        CanvasManager.canvasManager.UpdateCurrencyPanel(currentCurrency);
    }

    public void Deduct(int amount) {

        currentCurrency -= amount;
        CanvasManager.canvasManager.UpdateCurrencyPanel(currentCurrency);
    }

    public int GetCurrentCurrency() {

        return currentCurrency;
    }


    #endregion
}