using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Wave Config",menuName ="Wave Config SO")]
public class WayConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform enemyPath;
    [SerializeField] float enemyMoveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawn = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minSpawnTime = 0.2f;

    public Transform GetStartingWayPoint()
    {
        return enemyPath.GetChild(0);
    }
    public short GetEnemyCount()
    {
        return (short)enemyPrefabs.Count;
    }
    public GameObject GetEnemy(int index)
    {
        return enemyPrefabs[index];
    }
    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in enemyPath)
        {
            wayPoints.Add(child);
        }

        return wayPoints;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }
    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawn - spawnTimeVariance,timeBetweenEnemySpawn + spawnTimeVariance);

        return Mathf.Clamp(spawnTime,minSpawnTime,float.MaxValue); 
    }
}
