using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private int currentWeight;

    [SerializeField]
    private int maxWeight;

    [SerializeField]
    private List<Item> carriedItems;

    [SerializeField]
    private Weapons weapons;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Start() {

        foreach(Weapon weapon in weapons.weaponList)
            AddItem(weapon);
    }

    public void AddItem(Item item) {

        int newWeight = currentWeight + item.weight;

        if (newWeight > maxWeight) {
            Debug.Log("I can't carry anymore.");
            return;
        }

        carriedItems.Add(item);
        currentWeight += item.weight;

    }

    #endregion

}