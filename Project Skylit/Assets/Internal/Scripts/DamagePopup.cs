using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Animation animation;

    [SerializeField]
    private TMP_Text damageText;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Start() {

        PlayAnimation();
    }

    private void PlayAnimation() {

        int coin = Random.Range(0, 2);

        if (coin == 0)
            animation.Play("PopupLeft");
        else
            animation.Play("PopupRight");
    }

    public void AssignDamage(int _damage) {

        damageText.text = _damage.ToString();
    }

    private void Destroy() {

        Destroy(this.transform.parent.gameObject);
    }
    #endregion

}