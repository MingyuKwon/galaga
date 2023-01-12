using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMove : MonoBehaviour
{ 
    enemySpawner enemyspawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    Transform startPosition;
    int wayPointIndex = 0;

    private void Awake() {
        enemyspawner = FindObjectOfType<enemySpawner>();
    }

    void Start()
    {
        waveConfig = enemyspawner.GetCurrentWave();
        waypoints = waveConfig.GetWayPoints();
        startPosition = waveConfig.GetStartingWayPoint();
        returnStartPoint();

    }
    void Update()
    {
        Move();
    }
    void returnStartPoint()
    {
        transform.position = startPosition.position;
    }
    void Move()
    {
        if(wayPointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
                wayPointIndex++;

        }
        else
        {
            Destroy(transform.parent.gameObject);
        }

    }
}
