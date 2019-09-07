using UnityEngine;
using UnityEngine.AI;

public class BeastNavigator : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "

    public Transform target;

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    public void SetDestination(Transform destination)
    {
        target = destination;
        navMeshAgent.destination = target.position;

    }

    #endregion

}