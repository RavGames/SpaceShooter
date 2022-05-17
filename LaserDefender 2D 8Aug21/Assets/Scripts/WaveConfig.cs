using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("Wave") )]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathprefab;
    [SerializeField] int noOfEnemies;
    [SerializeField] float timeBetEachSpawn;
    [SerializeField] float enemySpeed;
    [SerializeField] float timeBetWaves;


    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetPathPrefab()
    {
        List<Transform> path = new List<Transform>();

        foreach (Transform child in pathprefab.transform)
        {
            path.Add(child);
        }

        return path;
    }

    public int GetNoOfEnimes()
    {
        return noOfEnemies;
    }

    public float GetEnemySpeed()
    {
        return enemySpeed;
    }

    public float GetTimeBetEachSpawn()
    {
        return timeBetEachSpawn;
    }

    public float GetTimeBetWaves()
    {
        return timeBetWaves;
    }
}
