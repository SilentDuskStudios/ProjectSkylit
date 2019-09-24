using UnityEngine;

public class GameManager : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    public static GameManager gameManager;

    public InputManager inputManager;

    public AirdropManager airdropManager;

    public ItemManager itemManager;

    public CurrencyManager currencyManager;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Awake() {

        if (gameManager == null) {

            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    #endregion

}