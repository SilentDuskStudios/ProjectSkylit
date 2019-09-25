using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeastHealthBar : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Slider healthBarSlider;

    [SerializeField]
    private Image healthBarBackground;

    [SerializeField]
    private Image healthBarForeground;

    [SerializeField]
    private TMP_Text healthBarPercentageText;

    private int healthbarPercentage;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Start() {

        HideHealthBar();
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth) {

        ShowHealthBar();
        healthBarSlider.value = (float)currentHealth / (float)maxHealth;

        float currentPercentage = (float)currentHealth / (float)maxHealth * 100;
        healthBarPercentageText.text = currentPercentage.ToString() + "%";
    }

    public void ShowHealthBar() {

        healthBarBackground.color = new Color(healthBarBackground.color.r, healthBarBackground.color.g, healthBarBackground.color.b, 1f);
        healthBarForeground.color = new Color(healthBarForeground.color.r, healthBarForeground.color.g, healthBarForeground.color.b, 1f);
        healthBarPercentageText.color = new Color(healthBarPercentageText.color.r, healthBarPercentageText.color.g, healthBarPercentageText.color.b, 1f);
    }
    
    public void HideHealthBar() {

        healthBarBackground.color = new Color(healthBarBackground.color.r, healthBarBackground.color.g, healthBarBackground.color.b, 0f);
        healthBarForeground.color = new Color(healthBarForeground.color.r, healthBarForeground.color.g, healthBarForeground.color.b, 0f);
        healthBarPercentageText.color = new Color(healthBarPercentageText.color.r, healthBarPercentageText.color.g, healthBarPercentageText.color.b, 0f);
    }

    #endregion //Methods
}