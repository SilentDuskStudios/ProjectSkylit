using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeastNavigator : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void SetDestination(Transform destination)
    {
        //TODO: Figure out a workaround. It seems like the issue is rooted in Maya.

        //TODO: Remove comments below as I can now get the correct position.
        //I cannot set the true position of the barricades, I must instead get the position of its box collider.
        //navMeshAgent.destination = destination.gameObject.GetComponent<Collider>().bounds.center;
        navMeshAgent.destination = destination.position;

    }
    #endregion
} 