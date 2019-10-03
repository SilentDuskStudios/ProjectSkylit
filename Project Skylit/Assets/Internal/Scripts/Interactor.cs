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

    //TODO: Figure out whether this should be initialised in the start() as its just the parent of this game object.
    [SerializeField]
    private SurvivorController survivorController;

    [SerializeField]
    private Weapons weapons;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Update() {

        if (inInteractionTrigger) {

            Ray interactionRay = new Ray(survivorCamera.transform.position, survivorCamera.transform.forward * interactionRange);

            if (Physics.Raycast(interactionRay, out RaycastHit hit, interactionRange, layerMask)) {
                //TODO: Pass hit.interactionType as oppossed to the type that ontriggerenter/stay/exit are providing in Interactions.cs
                CanvasManager.canvasManager.UpdateInteractionPanel(interactionType.Value);
            }
                
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
                        GameObject airdrop = hit.transform.gameObject;
                        airdrop.GetComponent<Animation>().Play("AirdropOpen");
                        airdrop.GetComponent<Airdrop>().interaction.DisableInteraction();
                        airdrop.GetComponent<Airdrop>().itemGameObject.GetComponent<Item>().interaction.EnableInteraction();
                        break;

                    case InteractionTypeEnum.Item:
                        Item item = hit.transform.gameObject.GetComponent<Airdrop>().item;
                        survivorController.inventoryController.AddItem(item);

                        if(item is Weapon) {
                            GameObject spawnedWeapon = GameManager.gameManager.itemManager.SpawnItem(item.ID, weapons.gameObject.transform);
                            weapons.AddWeapon(spawnedWeapon);
                        }

                        Destroy(hit.transform.gameObject.GetComponent<Airdrop>().itemGameObject);
                        break;
                }
            }
        }
    }
    #endregion
}