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

    public void UpdateWavePanel(int waveNumber) {

        wavePanel.UpdateWaveUI(waveNumber);
    }

    public void UpdateCurrencyPanel(int currency) {

        currencyPanel.UpdateCurrencyPanel(currency);
    }

    #endregion //Methods
}