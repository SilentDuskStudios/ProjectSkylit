using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeastNavigator : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    public void SetDestination(Transform _destination)
    {
        //Becaues I cannot set the true position of the barricades, I must get the position of its box collider.
        navMeshAgent.destination = _destination.gameObject.GetComponent<Collider>().bounds.center;

    } //SetDesintation

    #endregion //Methods

} //BeastNavigator