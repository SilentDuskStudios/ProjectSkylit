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

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    public void UpdateWeaponUI(string _weaponName, int _currentClip, int _currentReserveClip, Sprite image) {

        weaponNameText.text = _weaponName;
        weaponAmmoText.text = _currentClip.ToString() + " / " + _currentReserveClip.ToString();
        weaponImage.sprite = image;
    }

    #endregion //Methods
}