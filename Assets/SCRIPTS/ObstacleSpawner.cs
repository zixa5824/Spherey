using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject obstaclePrefab, jumpObstacle, jumpPad;
    public ObstacleMovement obstacleMovement;
    public float timeBetweenWaves = 1f;
    private float timeToSpawn = 2f;
    void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnObstacles();
            obstacleMovement.nextWave();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }
    void SpawnObstacles()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length+1);
        if(randomIndex == 6)
        {
            int randomPlace = Random.Range(0, spawnPoints.Length);
            Instantiate(jumpObstacle, new Vector3(0, spawnPoints[2].position.y, spawnPoints[2].position.z), Quaternion.identity);
            Instantiate(jumpPad, new Vector3(spawnPoints[randomPlace].position.x, spawnPoints[2].position.y, spawnPoints[2].position.z - 9), Quaternion.identity);
        }
        else
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (i != randomIndex)
                    Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }  
}
