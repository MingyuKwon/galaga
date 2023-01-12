using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefabs;
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] float delayTime = 0.5f;
    [SerializeField] float delayRandomGap = 0.3f;
    [SerializeField] float delayMinimum = 0.2f;

    public Transform GetStartingWayPoint()
    {
        return pathPrefabs.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefabs)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(delayTime - delayRandomGap, delayTime + delayRandomGap);
        return Mathf.Clamp(spawnTime, delayMinimum, float.MaxValue);
    }


}
