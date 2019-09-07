using System.Collections.Generic;

using UnityEngine;

public class BeastSpawner : MonoBehaviour {

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

    private WaveManager waveManager;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Start()
    {

        ResetTimers();

        InitialiseBeastSpawnPoints(ref beastSpawnLocations, beastSpawnerParent);
        InitialiseBeastSpawnPoints(ref barricadeLocations, barricadeParent);

        waveManager = WaveManager.waveManager;
    } 

    private void InitialiseBeastSpawnPoints(ref List<Transform> list, Transform parent)
    {
        list = new List<Transform>();

        int i = 0;
        foreach(Transform child in parent)
        {
            list.Add(child);
            i++;
        }

    }

    private void Update()
    {
        currentTimer += Time.deltaTime;

        if((waveManager.CanSpawnBeast()) && (currentTimer >= spawnTime)) {

            SpawnBeast();
            ResetTimers();

        }

    }

    private void ResetTimers()
    {
        currentTimer = 0f;
        spawnTime = SetSpawnTime();

    }

    private float SetSpawnTime()
    {
        return Random.Range(1f, 3f);

    }

    //TODO: Add a parameter of type Enum that spawns specific beasts
    private void SpawnBeast()
    {
        int _beastSpawnLocationIndex = Random.Range(0, beastSpawnLocations.Count);

        var _beast = Instantiate(beast, beastSpawnLocations[_beastSpawnLocationIndex].transform.position,
                           beastSpawnLocations[_beastSpawnLocationIndex].transform.rotation);

        int _barricadeLocationsIndex = Random.Range(0, barricadeLocations.Count);

        //NOTES: One about when the barricade is destroyed, how do we update the beasts target to go to the survivor.
        _beast.GetComponent<BeastNavigator>().SetDestination(barricadeLocations[_barricadeLocationsIndex]);

        waveManager.currentBeastCount++;
        waveManager.beastSpawnCount++;

    }

    #endregion

}