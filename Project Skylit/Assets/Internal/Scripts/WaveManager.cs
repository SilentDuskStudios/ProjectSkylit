using UnityEngine;

public class WaveManager : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    public static WaveManager waveManager;

    private int waveNumber;

    public int currentBeastCount;

    public int beastSpawnCount;

    private int maxBeastCount;

    public int beastObeseSpawnCount;

    public int maxBeastObeseSpawnCount;

    public int beastSprinterSpawnCount;

    public int maxBeastSprinterSpawnCount;

    public int beastBossSpawnCount;

    public int maxBeastBossSpawnCount;

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

        maxBeastBossSpawnCount = 1;
        
    }

    private void NextWave() {

        waveNumber++;
        currentBeastCount = 0;
        maxBeastCount += 2;
        beastSpawnCount = 0;

        maxBeastObeseSpawnCount += 1;
        maxBeastSprinterSpawnCount += 1;

        beastObeseSpawnCount = 0;
        beastSprinterSpawnCount = 0;
        beastBossSpawnCount = 0;
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

    public bool HasReachedSpawnCap(BeastTypeEnum beastType) {

        switch(beastType) {

            case BeastTypeEnum.obese:
                if(beastObeseSpawnCount >= maxBeastObeseSpawnCount)
                    return true;
                break;

            case BeastTypeEnum.sprinter:
                if(beastSprinterSpawnCount >= maxBeastSprinterSpawnCount)
                    return true;
                break;

            case BeastTypeEnum.boss:
                if(beastBossSpawnCount >= maxBeastBossSpawnCount)
                    return true;
                break;
        }

        return false;
    }

    #endregion

}