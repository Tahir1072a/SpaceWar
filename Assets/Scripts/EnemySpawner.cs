using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WayConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] WayConfigSO configSO;

    [SerializeField] bool isLooping;

    public WayConfigSO GetCurrentConfigSO()
    {
        return configSO;
    }
    private void Start()
    {
       StartCoroutine(SpawnEnemyWaves());
    }
    private IEnumerator SpawnEnemyWaves()
    {
        do
        {
            for (int j = 0; j < waveConfigs.Count; j++)
            {
                configSO = waveConfigs[j];
                for (int i = 0; i < configSO.GetEnemyCount(); i++)
                {
                    Instantiate(configSO.GetEnemy(i), configSO.GetStartingWayPoint().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(configSO.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }

        } while (isLooping);
    }
}
