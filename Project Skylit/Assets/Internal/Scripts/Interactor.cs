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
                CanvasManager.canvasManager.HideInteractionPanel();
        }
    }

    public void Interacting() {

        if(inInteractionTrigger) {

            Ray interactionRay = new Ray(survivorCamera.transform.position, survivorCamera.transform.forward * interactionRange);

            if(Physics.Raycast(interactionRay, out RaycastHit hit, interactionRange, layerMask)) {


                Debug.Log("You are interacting with: " + interactionType);
            }
        }
    }

    #endregion

}