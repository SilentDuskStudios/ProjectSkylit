using UnityEngine;

//TODO: Rename to Interactable
public class Interaction : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private InteractionTypeEnum interactionType;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void OnTriggerEnter(Collider other) {

        
        if (other.gameObject.tag == "Survivor") {

            other.gameObject.GetComponent<Survivor>().survivorController.interactionController.interactor.inInteractionTrigger = true;
            other.gameObject.GetComponent<Survivor>().survivorController.interactionController.interactor.interactionType = this.interactionType;
        }
    }

    private void OnTriggerStay(Collider other) {

        if (other.gameObject.tag == "Survivor") {

            other.gameObject.GetComponent<Survivor>().survivorController.interactionController.interactor.inInteractionTrigger = true;
            other.gameObject.GetComponent<Survivor>().survivorController.interactionController.interactor.interactionType = this.interactionType;
        }
    }
    

    private void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Survivor") {

            other.gameObject.GetComponent<Survivor>().survivorController.interactionController.interactor.inInteractionTrigger = false;
            other.gameObject.GetComponent<Survivor>().survivorController.interactionController.interactor.interactionType = null;
            CanvasManager.canvasManager.DisableInteractionPanel();
        }
    }

    public void EnableInteraction() {

        foreach (Transform child in this.gameObject.transform)
            child.gameObject.SetActive(true);

        this.gameObject.SetActive(true);
    }

    public void DisableInteraction() {

        foreach (Transform child in this.gameObject.transform)
            child.gameObject.SetActive(false);

        this.gameObject.SetActive(false);
    }

    public InteractionTypeEnum GetInteractionType() {

        return interactionType;
    }

    #endregion

}