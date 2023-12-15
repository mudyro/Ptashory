using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class SeedShooter : MonoBehaviour
{
    public GameObject seedPrefab;
    public GameObject seedPrefabCopy;
    GameObject newSeedPrefab;
    GameObject newSeedPrefabCopy;
    GameObject chickenObject;

    double lastSpawnTime;
    float shootingSpeed;
    double spawnTime = 0.417f;
    double spawnTimeForTriple = 0.55f;
    float sideVelocity = 0.08f;

    Vector3 seedDirection;
    Vector3 seedVelocity;
    
    public static Stopwatch spawnTimer;

    void Start()
    {   
        lastSpawnTime = 0;
        shootingSpeed = 45f;
        seedDirection = Vector3.forward;
        seedVelocity = seedDirection * shootingSpeed;
        chickenObject = GameObject.Find((PlayerPrefs.GetString("EquippedBird","01_CommonBirdIcon(Clone)").Substring(0,PlayerPrefs.GetString("EquippedBird").Length -11)));

        spawnTimer = new Stopwatch();
    }

    void Update()
    {
        if(chickenObject == null)
        {
            chickenObject = GameObject.Find((PlayerPrefs.GetString("EquippedBird","01_CommonBirdIcon(Clone)").Substring(0,PlayerPrefs.GetString("EquippedBird").Length -11)));
        }

        if (PlayerPrefs.GetString("EquippedSeed","02_CommonSeedIcon(Clone)") == "02_CommonSeedIcon(Clone)")
        {
            SpawnAndShootSingleShot();
        }
        else if (PlayerPrefs.GetString("EquippedSeed","02_CommonSeedIcon(Clone)") == "02_RareSeedIcon(Clone)")
        {

            SpawnAndShootTripleShot();
        }
        else if (PlayerPrefs.GetString("EquippedSeed","02_CommonSeedIcon(Clone)") == "02_LegSeedIcon(Clone)")
        {
            SpawnAndShootSinShot();
        }
    }

    // void SpawnAndShoot()
    // {
    //     if (lastSpawnTime + spawnTime < Time.time)
    //     {
    //         newSeedPrefab = Instantiate(seedPrefab,chickenObject.transform.position + Vector3.up * 0.5f,Quaternion.identity);
    //         Rigidbody seedRigidBody = newSeedPrefab.GetComponent<Rigidbody>();
    //         seedRigidBody.velocity = seedVelocity;
    //         lastSpawnTime = Time.time;
    //     }
    // }

    void SpawnAndShootSingleShot()
    {
        if (spawnTimer.Elapsed.TotalSeconds == 0) spawnTimer.Start();

        if (lastSpawnTime + spawnTime < spawnTimer.Elapsed.TotalSeconds)
        {       
            newSeedPrefab = Instantiate(seedPrefab,chickenObject.transform.position + Vector3.up * 0.5f,Quaternion.identity);
            Rigidbody seedRigidBody = newSeedPrefab.GetComponent<Rigidbody>();
            seedRigidBody.velocity = seedVelocity;
            lastSpawnTime += spawnTime;
        }
    }

    void SpawnAndShootTripleShot()
    {
        if (spawnTimer.Elapsed.TotalSeconds == 0) spawnTimer.Start();

        if (lastSpawnTime + spawnTimeForTriple < spawnTimer.Elapsed.TotalSeconds)
        {    
            for (int i = -1; i <= 1; i++)
            {
                newSeedPrefab = Instantiate(seedPrefab,chickenObject.transform.position + Vector3.up * 0.5f,Quaternion.identity);
                Rigidbody seedRigidBody = newSeedPrefab.GetComponent<Rigidbody>();
                Vector3 tripleSeedVelocity = new Vector3(sideVelocity * i,0,1) * shootingSpeed;
                seedRigidBody.velocity = tripleSeedVelocity;
            }   
                lastSpawnTime += spawnTimeForTriple;
        }
    }

    public void SpawnAndShootSinShot()
    {
        if (spawnTimer.Elapsed.TotalSeconds == 0) spawnTimer.Start();

        if (lastSpawnTime + spawnTime < spawnTimer.Elapsed.TotalSeconds)
        {   
                shootingSpeed = 30f;
                newSeedPrefab = Instantiate(seedPrefab,chickenObject.transform.position + Vector3.up * 0.5f,Quaternion.identity);
                Rigidbody seedRigidBody = newSeedPrefab.GetComponent<Rigidbody>();
                seedRigidBody.velocity = new Vector3(0,0,2f) * shootingSpeed;

                newSeedPrefabCopy = Instantiate(seedPrefabCopy,chickenObject.transform.position + Vector3.up * 0.5f,Quaternion.identity);
                Rigidbody seedRigidBodyCopy = newSeedPrefabCopy.GetComponent<Rigidbody>();
                seedRigidBodyCopy.velocity = new Vector3(0,0,2f) * shootingSpeed;

                lastSpawnTime += spawnTime;
        }
        
    }

   
}

