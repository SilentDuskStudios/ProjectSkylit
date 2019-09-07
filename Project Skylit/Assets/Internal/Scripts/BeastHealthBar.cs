using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeastHealthBar : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Slider healthBarSlider;

    [SerializeField]
    private Image healthBarBackground;

    [SerializeField]
    private Image healthBarForeground;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Start() {

        HideHealthBar();
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth) {

        ShowHealthBar();
        healthBarSlider.value = (float)currentHealth / (float)maxHealth;
    }

    public void ShowHealthBar() {

        healthBarBackground.color = new Color(healthBarBackground.color.r, healthBarBackground.color.g, healthBarBackground.color.b, 1f);
        healthBarForeground.color = new Color(healthBarForeground.color.r, healthBarForeground.color.g, healthBarForeground.color.b, 1f);

    }
    
    public void HideHealthBar() {

        healthBarBackground.color = new Color(healthBarBackground.color.r, healthBarBackground.color.g, healthBarBackground.color.b, 0f);
        healthBarForeground.color = new Color(healthBarForeground.color.r, healthBarForeground.color.g, healthBarForeground.color.b, 0f);
    }

    #endregion //Methods
}