using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Barricade : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;

    [SerializeField]
    private Transform[] barricadeStatuses;

    private Transform currentBarricadeStatus;
    private int currentBarricadeStatusIndex;

    [SerializeField]
    private NavMeshObstacle navMeshObstacle;

    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        currentBarricadeStatusIndex = 4;
        currentBarricadeStatus = barricadeStatuses[currentBarricadeStatusIndex];
        barricadeStatuses[currentBarricadeStatusIndex].gameObject.SetActive(true);
    }

    //TODO: Remove as this is for prototyping purposes.
    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
            TakeDamage(5);

        if (Input.GetButtonDown("Fire1"))
            Repair(5);
    }

    public void TakeDamage(int damage)
    {
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

    //Enable or disable the nav mesh obstacle component depending on whether the barricade is still present.
    private void SetNavMeshObstacle()
    {
        if (currentBarricadeStatusIndex == 0)
            navMeshObstacle.enabled = false;
        else
            navMeshObstacle.enabled = true;
    }
}