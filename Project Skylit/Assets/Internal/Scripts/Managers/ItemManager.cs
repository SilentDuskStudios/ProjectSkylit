using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    public List<Item> itemDatabase;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public Item GetItem(int ID) {

        return itemDatabase.Find(x => x.ID == ID);
    }

    public GameObject SpawnItem(int ID, Transform location) {

        GameObject spawnedItem = Instantiate(itemDatabase[ID].gameObject, location.position, location.rotation);

        return spawnedItem;
    }

    #endregion

}