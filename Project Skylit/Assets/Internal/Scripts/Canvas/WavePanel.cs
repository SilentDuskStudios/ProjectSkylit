using TMPro;
using UnityEngine;

public class WavePanel : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private TMP_Text waveNumberText;


    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void UpdateWaveUI(int waveNumber) {

        waveNumberText.text = waveNumber.ToString();
    }

    public void EnableWavePanel() {

        this.gameObject.SetActive(true);
    }

    public void DisableWavePanel() {

        this.gameObject.SetActive(false);
    }

    #endregion

}