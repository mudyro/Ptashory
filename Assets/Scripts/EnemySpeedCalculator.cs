using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class EnemySpeedCalculator : MonoBehaviour
{

    public static Stopwatch roundTimer;
    public static float interpolationValue;
    EnemySpawner enemySpawner;
    public float minSpawnTime;
    public float maxSpawnTime;

    void Start()
    {
        roundTimer = new Stopwatch();
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        maxSpawnTime = 1f;
        minSpawnTime = 0.4f;
    }

    void Update() 
    {
        if (roundTimer.Elapsed.TotalSeconds == 0) roundTimer.Start();
        interpolationValue = Mathf.Clamp01((float)roundTimer.Elapsed.TotalSeconds/30);
        enemySpawner.spawnTime = Mathf.Lerp(maxSpawnTime,minSpawnTime,interpolationValue);
    }

    public float enemySpeed(float speedMin, float speedMax)
    {
        float enemySpeed = Mathf.Lerp(speedMin,speedMax,interpolationValue);
        return enemySpeed;
    }
    
}
