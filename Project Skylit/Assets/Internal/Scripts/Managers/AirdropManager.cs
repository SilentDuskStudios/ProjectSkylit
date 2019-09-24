using UnityEngine;

public class AirdropManager : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Airdrop airdrop;

    [SerializeField]
    private Transform airdropLocation;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void SpawnAirdrop(Item item) {

        Airdrop _airdrop = Instantiate(airdrop.gameObject, airdropLocation.position, airdropLocation.rotation).GetComponent<Airdrop>();

        _airdrop.AddItemToAirdrop(item);
    }

    #endregion

}