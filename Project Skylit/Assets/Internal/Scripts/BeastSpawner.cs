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

    //Spawning the beasts at random spawn locations
    [SerializeField]
    private Transform[] beastSpawnLocations;
    private int beastSpawnLocationCount;

    //Telling the beasts which barricade to go to once spawned.
    [SerializeField]
    private Transform[] barricadeLocations;
    private int barricadeLocationsCount;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Start()
    {
        ResetTimers();
        beastSpawnLocationCount = beastSpawnLocations.Length;
        barricadeLocationsCount = barricadeLocations.Length;

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

        var _beast = Instantiate(beast, beastSpawnLocations[_beastSpawnLocationIndex].transform.position,
                           beastSpawnLocations[_beastSpawnLocationIndex].transform.rotation);

        int _barricadeLocationsIndex  = Random.Range(0, barricadeLocationsCount);

        _beast.GetComponent<BeastNavigator>().SetDestination(barricadeLocations[_barricadeLocationsIndex]);

    } //SpawnBeast

    #endregion //Methods

} //BeastSpawner