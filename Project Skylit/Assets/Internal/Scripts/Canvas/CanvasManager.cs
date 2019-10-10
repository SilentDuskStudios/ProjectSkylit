using UnityEngine;

//Singleton
public class CanvasManager : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "

    public static CanvasManager canvasManager;

    [SerializeField]
    private WeaponPanel weaponPanel;

    [SerializeField]
    private WavePanel wavePanel;

    [SerializeField]
    private CurrencyPanel currencyPanel;

    [SerializeField]
    private BarricadePanel barricadePanel;

    [SerializeField]
    private InteractionPanel interactionPanel;

    [SerializeField]
    private ShopPanel shopPanel;

    [SerializeField]
    private ReticlePanel reticlePanel;

    [SerializeField]
    private SkillPanel skillPanel;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Awake() {

        if (canvasManager == null) {

            canvasManager = this;
            DontDestroyOnLoad(gameObject);

        }
        else
            Destroy(this.gameObject);
    }


    public void UpdateWeaponPanel(string weaponName, int currentClip, int currentReserveClip, Sprite image) {

        weaponPanel.UpdateWeaponUI(weaponName, currentClip, currentReserveClip, image);
        
    }

    public void UpdateWeaponPanel(float reloadTime) {

        weaponPanel.UpdateReloadBar(reloadTime);
    }


    public void UpdateWavePanel(int waveNumber) {

        wavePanel.UpdateWaveUI(waveNumber);
    }

    public void UpdateCurrencyPanel(int currency) {

        currencyPanel.UpdateCurrencyPanel(currency);
    }

    public void UpdateBarricadePanel(int barricadeID, int currentHealth, int maxHealth) {

        barricadePanel.UpdateBarricadeHealthBar(barricadeID, currentHealth, maxHealth);
    }

    public void UpdateInteractionPanel(InteractionTypeEnum interactionType) {

        interactionPanel.UpdateInteractionPanel(interactionType);
    }

    public void UpdateSkillPanel(int skillpoints) {

        skillPanel.UpdateSkillPanel(skillpoints);
    }

    public void DisableInteractionPanel() {

        interactionPanel.DisableInteractionPanel();
    }

    public void EnableShopPanel() {

        DisableMainPanels();
        shopPanel.EnableShopPanel();
        GameManager.gameManager.inputManager.EnableCursor();
        GameManager.gameManager.inputManager.DisableSurvivorControls();
    }

    public void DisableShopPanel() {

        EnableMainPanels();
        shopPanel.DisableShopPanel();
        GameManager.gameManager.inputManager.DisableCursor();
        GameManager.gameManager.inputManager.EnableSurvivorControls();
    }

    public void EnableSkillPanel(int skillpoints) {

        DisableMainPanels();
        skillPanel.EnableSkillPanel(skillpoints);
        GameManager.gameManager.inputManager.EnableCursor();
        GameManager.gameManager.inputManager.DisableSurvivorControls();
    }

    public void DisableSkillPanel() {

        EnableMainPanels();
        skillPanel.DisableSkillPanel();
        GameManager.gameManager.inputManager.DisableCursor();
        GameManager.gameManager.inputManager.EnableSurvivorControls();
    }

    private void EnableMainPanels() {

        weaponPanel.EnableWeaponPanel();
        wavePanel.EnableWavePanel();
        currencyPanel.EnableCurrencyPanel();
        barricadePanel.EnableBarricadePanel();
        reticlePanel.EnableReticlePanel();
    }

    private void DisableMainPanels() {

        weaponPanel.DisableWeaponPanel();
        wavePanel.DisableWavePanel();
        currencyPanel.DisableCurrencyPanel();
        barricadePanel.DisableBarricadePanel();
        reticlePanel.DisableReticlePanel();
    }

    #endregion //Methods
}
 