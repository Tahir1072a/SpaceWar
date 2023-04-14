using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WayConfigSO configSO;
    List<Transform> wayPoints;
    int wayPointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
    }
    private void Start()
    {
        configSO = enemySpawner.GetCurrentConfigSO();
        wayPoints = configSO.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].position;
    }

    private void Update()
    {
        FallowPath();
    }

    private void FallowPath()
    {
        if(wayPointIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointIndex].position;
            float delta = configSO.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
