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

                //TODO: Add a switch case to determine what to do with what you are interacting with...
                CanvasManager.canvasManager.EnableShopPanel();
            }
        }
    }

    #endregion

}