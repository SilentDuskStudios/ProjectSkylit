using UnityEngine;

public class AirdropManager : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Airdrop airdrop;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void SpawnAirdrop(Item item) {

        Airdrop spawnedAirdrop = Instantiate(airdrop.gameObject, this.transform.position, this.transform.rotation).GetComponent<Airdrop>();
        spawnedAirdrop.AddItemToAirdrop(item);

        GameObject spawnedItem = GameManager.gameManager.itemManager.SpawnItem(item.ID, spawnedAirdrop.itemPlaceholder.transform);
        spawnedItem.transform.SetParent(spawnedAirdrop.itemPlaceholder.transform);

        spawnedAirdrop.itemGameObject = spawnedAirdrop.itemPlaceholder.transform.GetChild(0).gameObject;
    }

    #endregion

}