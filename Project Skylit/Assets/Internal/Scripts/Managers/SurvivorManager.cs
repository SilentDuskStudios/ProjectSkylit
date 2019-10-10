using System.Collections.Generic;
using UnityEngine;

public class SurvivorManager : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private List<Survivor> survivors;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Start() {
        
        //TODO: Initialise survivors...but how? Maybe when initialising the game session, when instantiating survivoirs, fill out survivors in a method.
    }

    public List<Survivor> GetSurvivors() {

        return survivors;
    }

    //TODO: This method should return the local player, but for now, it'll return the first survivor as it is solo play.
    public Survivor GetLocalPlayer() {
        return survivors[0];
    }

    #endregion

}