using UnityEngine;

public class Skills : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private Survivor survivor;

    public int skillpoint;

    [SerializeField]
    private int damageSkill;

    [SerializeField]
    private int reloadSpeedSkill;
    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void AddSkillpoint() {

        skillpoint++;
        CanvasManager.canvasManager.UpdateSkillPanel(skillpoint);
    }

    public void IncreaseSkill(string skillType) {

        switch (skillType) {

            case "Damage":
                damageSkill++;

                float damageModifier = GameManager.gameManager.skillManager.GetDamageModifier(damageSkill);
                survivor.survivorController.weaponController.weapons.UpdateAllWeaponsDamage(damageModifier);
                break;
        }

        skillpoint--;
    }

    public int GetDamageLevel() {

        return damageSkill;
    }

    public bool HasSkillpoint() {

        if (skillpoint > 0)
            return true;

        return false;
    }

    #endregion

}