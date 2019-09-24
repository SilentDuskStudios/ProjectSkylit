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

    public void BuyItem(int ID) {

        Item item = GameManager.gameManager.itemManager.GetItem(ID);

        Debug.Log("You have purchased: " + item.itemName);
        CanvasManager.canvasManager.DisableShopPanel();

        GameManager.gameManager.airdropManager.SpawnAirdrop(item);
    }

    #endregion
}