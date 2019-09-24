using UnityEngine;

public class Airdrop : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Rigidbody rigidBody;

    private bool parachuteDeployed;

    private Ray altitudeRay;

    [SerializeField]
    private float altitudeRange;

    [SerializeField]
    private LayerMask layerMask;

    public Item item;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Update() {

        if (!parachuteDeployed)
            CheckAltitude();
    }

    private void CheckAltitude() {

        altitudeRay = new Ray(this.transform.position, -this.transform.up * altitudeRange);

        if(Physics.Raycast(altitudeRay, out RaycastHit hit, altitudeRange, layerMask))
            DeployParachute();
    }

    private void DeployParachute() {

        rigidBody.drag = 2.5f;
        parachuteDeployed = true;
        //TODO: Perform parachute animation.
    }

    public void AddItemToAirdrop(Item _item) {

        item = _item;
    }

    #endregion

}