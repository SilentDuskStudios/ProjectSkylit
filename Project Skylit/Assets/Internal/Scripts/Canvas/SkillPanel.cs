using TMPro;
using UnityEngine;

public class SkillPanel : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private TMP_Text skillpointValue;

    [SerializeField]
    private SkillGroup[] skillGroup;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void EnableSkillPanel(int skillpoints) {

        this.gameObject.SetActive(true);
        skillpointValue.text = skillpoints.ToString();
    }

    public void DisableSkillPanel() {

        this.gameObject.SetActive(false);
    }

    public void UpdateSkillPanel(int skillpoints) {

        skillpointValue.text = skillpoints.ToString();
        //TODO: Update SkillGroup values.
    }

    public void IncreaseSkill(string skillType) {

        Survivor survivor = GameManager.gameManager.survivorManager.GetLocalPlayer();

        if (!survivor.survivorController.skillController.skills.HasSkillpoint()) {
            //TODO: Display message informing survivor that they need more skill points!
            Debug.Log("You don't have enough skill points!");
            return;
        }

        switch (skillType) {

            case "Damage":
                survivor.survivorController.skillController.skills.IncreaseSkill(skillType);
                //TODO: Instead of using magic numbers, find a way to select skill type.
                //TODO: Maybe you can utilise a SkillEnum for this. Assign for each skillGroup and query the correct one.
                skillGroup[0].UpdateSkillGroup(survivor.survivorController.skillController.skills.GetDamageLevel());
                break;
        }

        UpdateSkillPanel(survivor.survivorController.skillController.skills.skillpoint);
    }

    #endregion

}