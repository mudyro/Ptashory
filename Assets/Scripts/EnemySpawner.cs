using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class EnemySpawner : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    float currentSecond;
    float currentSecondTwo;
    float currentSecondThree;
    float enemyOneRunningSpeed;
    public float spawnTime;
    public float spawnTimeTwo;
    public float spawnTimeThree;
    float spawnRangeX;
    float spawnRangeZ;

    Vector3 enemyRunDirection;
    Vector3 enemyVelocity;
    Vector3 enemyTwoVelocity;
    Vector3 enemyThreeVelocity;
    Vector3 spawnPoint;

    public GameObject enemyPrefab;
    public GameObject levelTwoEnemyPrefab;
    public GameObject levelThreeEnemyPrefab;
    GameObject newEnemyPrefab;
    EnemySpeedCalculator enemyOneSpeedCalculator;

    public static Stopwatch enemySpawnStopwatch;

    void Start()
    {   
        enemyOneSpeedCalculator = GameObject.FindObjectOfType<EnemySpeedCalculator>();

        currentSecond = 0f;
        currentSecondTwo = 7.5f;
        currentSecondThree = 15f;

        enemyRunDirection = Vector3.back;

        spawnTime = 1f;
        spawnTimeTwo = 2.5f;
        spawnTimeThree = 4f;
        enemySpawnStopwatch = new Stopwatch();
    }

    void Update()
    {
        enemyOneRunningSpeed = enemyOneSpeedCalculator.enemySpeed(12f,25f);
        enemyVelocity = enemyRunDirection * enemyOneRunningSpeed;
        enemyTwoVelocity = enemyVelocity * 0.7f;
        enemyThreeVelocity = enemyVelocity * 1.2f;
        SpawnAndRun();
    }

    void SpawnAndRun()
    {
        if (enemySpawnStopwatch.Elapsed.TotalSeconds == 0) enemySpawnStopwatch.Start();
        {
            if (currentSecond + spawnTime < enemySpawnStopwatch.Elapsed.TotalSeconds)
            {
                spawnRangeX = Random.Range(-1.2f,1.2f);
                spawnRangeZ = Random.Range(25f,40f);
                spawnPoint = new Vector3(spawnRangeX,0.15f,spawnRangeZ);
                newEnemyPrefab = Instantiate(enemyPrefab,spawnPoint,Quaternion.Euler(0,180,0));
                Rigidbody enemyRigidBody = newEnemyPrefab.GetComponent<Rigidbody>();
                enemyRigidBody.velocity = enemyVelocity;
                currentSecond += spawnTime;

                if (currentSecondTwo + spawnTimeTwo < enemySpawnStopwatch.Elapsed.TotalSeconds && enemySpawnStopwatch.Elapsed.TotalSeconds >= 10)
                {
                    spawnRangeX = Random.Range(-1.2f,1.2f);
                    spawnRangeZ = Random.Range(40f,65f);
                    spawnPoint = new Vector3(spawnRangeX,0.15f,spawnRangeZ);
                    newEnemyPrefab = Instantiate(levelTwoEnemyPrefab,spawnPoint,Quaternion.Euler(0,180,0));
                    Rigidbody enemyRigidBodyTwo = newEnemyPrefab.GetComponent<Rigidbody>();
                    enemyRigidBodyTwo.velocity = enemyTwoVelocity;
                    currentSecondTwo += spawnTimeTwo;
                }
                
                if (currentSecondTwo + spawnTimeThree < enemySpawnStopwatch.Elapsed.TotalSeconds && enemySpawnStopwatch.Elapsed.TotalSeconds >= 20)
                {
                    spawnRangeX = Random.Range(-1.2f,1.2f);
                    spawnRangeZ = Random.Range(60f,80f);
                    spawnPoint = new Vector3(spawnRangeX,0.15f,spawnRangeZ);
                    newEnemyPrefab = Instantiate(levelThreeEnemyPrefab,spawnPoint,Quaternion.Euler(0,180,0));
                    Rigidbody enemyRigidBodyThree = newEnemyPrefab.GetComponent<Rigidbody>();
                    enemyRigidBodyThree.velocity = enemyThreeVelocity;
                    currentSecondThree += spawnTimeThree;

                }

            }
            
        }
    }
}
