using System.Collections.Generic;

using UnityEngine;

public class BeastSpawner : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    private float currentTimer;
    private float spawnTime;

    [SerializeField]
    private List<Beast> beasts;

    //Spawning the beasts at random spawn locations
    private List<Transform> beastSpawnLocations;

    [SerializeField]
    private Transform beastSpawnerParent;

    //Telling the beasts which barricade to go to once spawned.
    private List<Transform> barricadeLocations;

    [SerializeField]
    private Transform barricadeParent;

    private WaveManager waveManager;

    [SerializeField]
    private BeastNavigator beastNavigator;

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

    private Beast GetBeastType() {

        // 0 to 50  = normal   | [0]
        //51 to 70  = obese    | [1]
        //71 to 90  = sprinter | [2]
        //91 to 100 = boss     | [3]

        Beast _spawnedBeast;
        bool hasReachedSpawnCap = false;

        do {

            int _beastTypePercentage = Random.Range(0, 101);

            if ((_beastTypePercentage > -1) && (_beastTypePercentage < 51))
                _spawnedBeast = beasts[0];

            else if ((_beastTypePercentage > 50) && (_beastTypePercentage < 71))
                _spawnedBeast = beasts[1];

            else if ((_beastTypePercentage > 70) && (_beastTypePercentage < 91))
                _spawnedBeast = beasts[2];

            else
                _spawnedBeast = beasts[3];


            if (WaveManager.waveManager.HasReachedSpawnCap(_spawnedBeast.beastType))
                hasReachedSpawnCap = true;
            else
                hasReachedSpawnCap = false;

        } while (hasReachedSpawnCap);

        return _spawnedBeast;
    }

    private void SpawnBeast()
    {
        int _beastSpawnLocationIndex = Random.Range(0, beastSpawnLocations.Count);

        Beast _beastType = GetBeastType();

        Beast _beast = Instantiate(_beastType, beastSpawnLocations[_beastSpawnLocationIndex].transform.position,
                           beastSpawnLocations[_beastSpawnLocationIndex].transform.rotation);

        int _barricadeLocationsIndex = Random.Range(0, barricadeLocations.Count);

        //NOTES: One about when the barricade is destroyed, how do we update the beasts target to go to the survivor.
        _beast.GetComponent<BeastNavigator>().SetDestination(barricadeLocations[_barricadeLocationsIndex]);

        _beast.GetComponent<BeastNavigator>().InitialiseMovementSpeed((int)_beast.movementSpeed);

        waveManager.currentBeastCount++;
        waveManager.beastSpawnCount++;

        //TODO: Change beastXXSpawnCount to private and have a public method modify it.

        if (_beast.beastType == BeastTypeEnum.obese)
            WaveManager.waveManager.beastObeseSpawnCount++;

        else if (_beast.beastType == BeastTypeEnum.sprinter)
            WaveManager.waveManager.beastSprinterSpawnCount++;

        else if (_beast.beastType == BeastTypeEnum.boss)
            WaveManager.waveManager.beastBossSpawnCount++;

    }

    #endregion

}