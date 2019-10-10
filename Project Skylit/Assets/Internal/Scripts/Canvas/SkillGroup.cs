using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillGroup : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private TMP_Text skillTypeLabel;

    [SerializeField]
    private TMP_Text skillLevel;

    [SerializeField]
    private Button increaseButton;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void UpdateSkillGroup(int _skillLevel) {

        skillLevel.text = _skillLevel.ToString();
    }

    #endregion

}