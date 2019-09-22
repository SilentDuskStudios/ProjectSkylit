using UnityEngine;

public class ShopPanel : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "



    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void EnableShopPanel() {

        this.gameObject.SetActive(true);
    }

    public void DisableShopPanel() {

        this.gameObject.SetActive(false);
    }

    public void BuyItem(string itemName) {

        Debug.Log("You have purchased: " + itemName);
        CanvasManager.canvasManager.DisableShopPanel();
    }

    #endregion
}