using UnityEngine;

public class InventoryController : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Inventory inventory;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void AddItem(Item item) {

        inventory.AddItem(item);
        
    }

    public void DropItem(Item item) {

    }

    public void SwapItem(Item item) {

    }

    #endregion

}