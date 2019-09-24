using UnityEngine;

public class Interactor : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    public bool inInteractionTrigger;

    [SerializeField]
    private Camera survivorCamera;

    [SerializeField]
    private float interactionRange;

    [SerializeField]
    private LayerMask layerMask;

    public InteractionTypeEnum? interactionType;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Update() {

        if (inInteractionTrigger) {

            Ray interactionRay = new Ray(survivorCamera.transform.position, survivorCamera.transform.forward * interactionRange);

            if (Physics.Raycast(interactionRay, out RaycastHit hit, interactionRange, layerMask))
                CanvasManager.canvasManager.UpdateInteractionPanel(interactionType.Value);
            else
                CanvasManager.canvasManager.DisableInteractionPanel();
        }
    }

    public void Interacting() {

        if(inInteractionTrigger) {

            Ray interactionRay = new Ray(survivorCamera.transform.position, survivorCamera.transform.forward * interactionRange);

            if(Physics.Raycast(interactionRay, out RaycastHit hit, interactionRange, layerMask)) {

                switch (interactionType) {
                    case InteractionTypeEnum.Shop:
                        CanvasManager.canvasManager.EnableShopPanel();
                        break;

                    case InteractionTypeEnum.Airdrop:
                        Debug.Log("You have retrieved a: " + hit.transform.gameObject.GetComponent<Airdrop>().item.itemName);
                        break;
                }

                
            }
        }
    }

    #endregion

}