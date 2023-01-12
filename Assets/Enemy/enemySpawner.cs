using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float tiemBetweenWaves= 0.2f;
    [SerializeField] bool lsLoopoing;

    WaveConfigSO currentWave;

    void Start()
    {
         StartCoroutine(spawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator spawnEnemyWaves()
    {
        do{
            foreach(WaveConfigSO w in waveConfigs)
        {
            currentWave = w;
           
            for(int i=0; i< currentWave.GetEnemyCount(); i++)
            {
            GameObject enemy =  Instantiate(currentWave.GetEnemyPrefab(i), 
            currentWave.GetStartingWayPoint().position,
            Quaternion.identity,
            transform);
            enemy.GetComponentInChildren<Shooter>().isAI = true;

            if(i < (currentWave.GetEnemyCount()-1)) 
                yield return new WaitForSecondsRealtime(currentWave.GetRandomSpawnTime());
            }

            yield return new WaitForSeconds(tiemBetweenWaves);
        }

        }while(lsLoopoing);
        
    }
}
