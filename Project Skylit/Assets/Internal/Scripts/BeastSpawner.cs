using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastSpawner : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "

    private float currentTimer;
    private float spawnTime;

    [SerializeField]
    private GameObject beast;

    [SerializeField]
    private Transform[] beastSpawnLocations;
    private int beastSpawnLocationCount;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Start()
    {
        ResetTimers();
        beastSpawnLocationCount = beastSpawnLocations.Length;

    } //Start

    private void Update()
    {
        currentTimer += Time.deltaTime;

        if (currentTimer >= spawnTime)
        {
            SpawnBeast();
            ResetTimers();
        }

    } //Update

    private void ResetTimers()
    {
        currentTimer = 0f;
        spawnTime = SetSpawnTime();

    } //ResetTimers

    private float SetSpawnTime()
    {
        return Random.Range(1f, 3f);

    } //SetSpawnTime

    //TODO: Add a parameter of type Enum that spawns specific beasts.
    private void SpawnBeast()
    {
        int _beastSpawnLocationIndex = Random.Range(0, beastSpawnLocationCount);

        Instantiate(beast, beastSpawnLocations[_beastSpawnLocationIndex].transform.position,
                           beastSpawnLocations[_beastSpawnLocationIndex].transform.rotation);

    } //SpawnBeast

    #endregion //Methods

} //BeastSpawner