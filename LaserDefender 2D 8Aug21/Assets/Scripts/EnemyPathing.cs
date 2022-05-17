using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    WaveConfig waveConfig;
     List<Transform> wayPoints;
    
    int wayPointIndex = 0;


    private void Start()
    {
        wayPoints = waveConfig.GetPathPrefab();
        transform.position = wayPoints[wayPointIndex].transform.position;
    }


    private void Update()
    {
        if(wayPointIndex <= wayPoints.Count - 1)
        {
            var targetPos = wayPoints[wayPointIndex].transform.position;

            transform.position = Vector2.MoveTowards(transform.position,
                                                        targetPos,
                                                        waveConfig.GetEnemySpeed() * Time.deltaTime);

            if(transform.position == targetPos)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetEnemyPath(WaveConfig waveConfigs)
    {
        this.waveConfig = waveConfigs;
    }

}// CLASS
