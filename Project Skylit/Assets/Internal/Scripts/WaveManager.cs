using UnityEngine;

public class WaveManager : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    public static WaveManager waveManager;

    private int waveNumber;

    public int currentBeastCount;

    public int beastSpawnCount;

    private int maxBeastCount;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Awake() {

        if (waveManager == null) {

            waveManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start() {

        waveNumber = 1;
        currentBeastCount = 0;
        maxBeastCount = 10;
        beastSpawnCount = 0;
    }

    private void NextWave() {

        waveNumber++;
        currentBeastCount = 0;
        maxBeastCount += 5;
        beastSpawnCount = 0;
    }

    public bool CanSpawnBeast() {

        if (beastSpawnCount < maxBeastCount)
            return true;

        return false;

    }

    public void CheckNextWave() {

        if ((currentBeastCount == 0) && (beastSpawnCount == maxBeastCount)) {

            NextWave();
        }
    }

    #endregion

}