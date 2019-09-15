using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPanel : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private TMP_Text weaponNameText;

    [SerializeField]
    private TMP_Text weaponAmmoText;

    [SerializeField]
    private Image weaponImage;

    [SerializeField]
    private Slider reloadBarSlider;

    [SerializeField]
    private Image reloadBarBackground;

    [SerializeField]
    private Image reloadBarForeground;

    private bool reloading;

    private float reloadTimer;

    private float reloadTime;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Update() {

        if (reloading) {

            reloadTimer += Time.deltaTime;
            reloadBarSlider.value = reloadTimer / reloadTime;

            if (reloadTimer >= reloadTime)
                ResetReloadBar();
        }
    }

    public void UpdateWeaponUI(string _weaponName, int _currentClip, int _currentReserveClip, Sprite image) {

        weaponNameText.text = _weaponName;
        weaponAmmoText.text = _currentClip.ToString() + " / " + _currentReserveClip.ToString();
        weaponImage.sprite = image;
    }

    public void UpdateReloadBar(float _reloadTime) {

        reloadBarSlider.gameObject.SetActive(true);
        reloadTime = _reloadTime;
        reloading = true;
    }

    private void ResetReloadBar() {

        reloading = false;
        reloadTimer = 0f;
        reloadBarSlider.gameObject.SetActive(false);
    }

    #endregion //Methods
}