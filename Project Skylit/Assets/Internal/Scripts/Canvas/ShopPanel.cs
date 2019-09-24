using UnityEngine;

public class ShopPanel : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private CurrencyPanel currencyPanel;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void OnEnable() {

        int currentCurrency = GameManager.gameManager.currencyManager.GetCurrentCurrency();
        currencyPanel.UpdateCurrencyPanel(currentCurrency);
    }

    public void EnableShopPanel() {

        this.gameObject.SetActive(true);
    }

    public void DisableShopPanel() {

        this.gameObject.SetActive(false);
    }

    public void BuyItem(int ID) {

        Item item = GameManager.gameManager.itemManager.GetItem(ID);

        int currentCurrency = GameManager.gameManager.currencyManager.GetCurrentCurrency();
        int itemPrice = item.price;
        
        //If Survivor has insufficient currency.
        if(currentCurrency < itemPrice) {
            Debug.Log("You do not have enough Currency.");
            Debug.Log("You have: " + currentCurrency);
            Debug.Log("The item price is: " + itemPrice);

            return;
        }

        GameManager.gameManager.currencyManager.Deduct(itemPrice);

        Debug.Log("You have purchased: " + item.itemName);
        CanvasManager.canvasManager.DisableShopPanel();

        GameManager.gameManager.airdropManager.SpawnAirdrop(item);
    }

    #endregion
}