using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Barricade : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "

    private int maxHealth;
    private int currentHealth;

    [SerializeField]
    private Transform[] barricadeStatuses;

    private Transform currentBarricadeStatus;
    private int currentBarricadeStatusIndex;

    [SerializeField]
    private NavMeshObstacle navMeshObstacle;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        currentBarricadeStatusIndex = 4;
        currentBarricadeStatus = barricadeStatuses[currentBarricadeStatusIndex];
        barricadeStatuses[currentBarricadeStatusIndex].gameObject.SetActive(true);
    }
 
    public void TakeDamage(int damage)
    {
        //TODO: Add armour so that damage is multiplied by the armour to provide the true damage to inflict.
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateMesh();
    }

    public void Repair(int repairAmount)
    {
        currentHealth += repairAmount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateMesh();
    }

    private void UpdateMesh()
    {
        int _updatedBarricadeStatusIndex = currentBarricadeStatusIndex;

        if (currentHealth <= 0)
        {
            _updatedBarricadeStatusIndex = 0;
        }
        else if((currentHealth >= 1) && (currentHealth <= 25))
        {
            _updatedBarricadeStatusIndex = 1;
        }
        else if((currentHealth >= 26) && (currentHealth <= 50))
        {
            _updatedBarricadeStatusIndex = 2;
        }
        else if((currentHealth >= 51) && (currentHealth <= 75))
        {
            _updatedBarricadeStatusIndex = 3;
        }
        else if((currentHealth >= 76) && (currentHealth <= 100))
        {
            _updatedBarricadeStatusIndex = 4;
        }

        //If the barricades mesh should be changed.
        if(currentBarricadeStatusIndex != _updatedBarricadeStatusIndex) 
        {
            barricadeStatuses[currentBarricadeStatusIndex].gameObject.SetActive(false);
            barricadeStatuses[_updatedBarricadeStatusIndex].gameObject.SetActive(true);

            currentBarricadeStatusIndex = _updatedBarricadeStatusIndex;


            SetNavMeshObstacle();
        }
    }

    //Setting the state of NavMeshObstacle component depending on whether the barricade is completely destroyed.
    private void SetNavMeshObstacle()
    {
        if (currentBarricadeStatusIndex == 0)
            navMeshObstacle.enabled = false;
        else
            navMeshObstacle.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //This could be dangerous because the beast could be chasing the survivor but is still in the barricade 
        //box collider even after it is destroyed.
        if(other.gameObject.tag == "Beast")
        {
            Beast beast = other.gameObject.GetComponent<Beast>();
            Transform target = beast.gameObject.GetComponent<BeastNavigator>().target;

            beast.canAttack = true;
        }
    }

    #endregion 
}