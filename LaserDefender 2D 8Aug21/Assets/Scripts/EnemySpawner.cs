using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigs;
    int currentWaveIndex = 0;
    [SerializeField] bool looping = false;


    IEnumerator Start()
    {

        do
        {
            // var startingWave = waveConfigs[currentWaveIndex];
            //var spawnOrderWave = waveConfigs[currentWaveIndex];
             yield return StartCoroutine(SpawnWave());
        }
        while (looping);
        
    }

    IEnumerator SpawnWave()
    {
        for(var startingWave = currentWaveIndex; startingWave < waveConfigs.Count; startingWave++)
        {
            var waveList = waveConfigs[startingWave];
            yield return StartCoroutine(SpawnEnemies(waveList));
        }
       
    }


    IEnumerator SpawnEnemies(WaveConfig waveConfig)
    {
        for (var enemyCount = 0; enemyCount < waveConfig.GetNoOfEnimes(); enemyCount++)
        {
            GameObject enemy = Instantiate(waveConfig.GetEnemyPrefab(),
                                            waveConfig.GetPathPrefab()[0].transform.position,
                                            Quaternion.identity) as GameObject;
            enemy.GetComponent<EnemyPathing>().SetEnemyPath(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetEachSpawn());

        }
    }

    

}// CLASS
