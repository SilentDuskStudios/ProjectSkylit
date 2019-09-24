using UnityEngine;

public class AirdropManager : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Airdrop airdrop;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void SpawnAirdrop(Item item) {

        Airdrop _airdrop = Instantiate(airdrop.gameObject, this.transform.position, this.transform.rotation).GetComponent<Airdrop>();

        _airdrop.AddItemToAirdrop(item);
    }

    #endregion

}