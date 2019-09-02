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
    private List<Transform> beastSpawnLocations;

    [SerializeField]
    private Transform beastSpawnerParent;

    //Telling the beasts which barricade to go to once spawned.
    private List<Transform> barricadeLocations;

    [SerializeField]
    private Transform barricadeParent;


    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Start()
    {

        ResetTimers();

        InitialiseList(ref beastSpawnLocations, beastSpawnerParent);
        InitialiseList(ref barricadeLocations, barricadeParent);

    } //Start

    private void InitialiseList(ref List<Transform> list, Transform parent)
    {
        list = new List<Transform>();

        int i = 0;
        foreach(Transform child in parent)
        {
            list.Add(child);
            i++;
        }

    } //InitialiseList

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

    }

    private float SetSpawnTime()
    {
        return Random.Range(1f, 3f);

    }

    //TODO: Add a parameter of type Enum that spawns specific beasts.
    private void SpawnBeast()
    {
        int _beastSpawnLocationIndex = Random.Range(0, beastSpawnLocations.Count);

        var _beast = Instantiate(beast, beastSpawnLocations[_beastSpawnLocationIndex].transform.position,
                           beastSpawnLocations[_beastSpawnLocationIndex].transform.rotation);

        int _barricadeLocationsIndex = Random.Range(0, barricadeLocations.Count);

        //NOTES: One about when the barricade is destroyed, how do we update the beasts target to go to the survivor.
        _beast.GetComponent<BeastNavigator>().SetDestination(barricadeLocations[_barricadeLocationsIndex]);

    }

    #endregion

}