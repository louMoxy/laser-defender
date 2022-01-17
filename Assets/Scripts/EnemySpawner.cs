using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    WaveConfigSO currentWave;

    void Start()
    {
      StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO waveConfig in waveConfigs)
            {
                currentWave = waveConfig;
                yield return StartCoroutine(SpawnEnemies());
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }

    IEnumerator SpawnEnemies()
    {
        for(int i = 0; i < currentWave.GetEmenyCount(); i++)
        {
            Instantiate(
                currentWave.GetEnemyPrefab(i),
                currentWave.GetStartingWaypoint().position,
                Quaternion.Euler(0, 0, 180),
                transform);
            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }
    }
}
