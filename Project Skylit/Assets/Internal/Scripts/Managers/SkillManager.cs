using System.Collections.Generic;

using UnityEngine;

public class SkillManager : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "


    #endregion

    #region " - - - - - - Methods - - - - - - "
    
    public void AddSkillpoints() {

        List<Survivor> survivors = GameManager.gameManager.survivorManager.GetSurvivors();

        foreach(Survivor survivor in survivors) {
            survivor.survivorController.skillController.skills.AddSkillpoint();
        }
    }

    public float GetDamageModifier(int damageLevel) {

        switch (damageLevel) {

            case 0:
                return 1f;
            case 1:
                return 1.2f;
            case 2:
                return 1.4f;
            case 3:
                return 1.6f;
            case 4:
                return 1.8f;
            case 5:
                return 2f;
            default:
                return 1f;
        }
    }

    #endregion

}