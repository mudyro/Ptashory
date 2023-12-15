using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class EnvSpawner : MonoBehaviour
{
    
    List<GameObject> firstSpawnedObjects = new List<GameObject>();

    int amountOfObjectsToSpawn;
    int amountOfObjectsToSpawnAtStart;

    float rangeMin = -15f;
    float rangeMax = -3f;
    float currentSecond;
    public float runningSpeed = 7f;
    float spawnTime;
    float spawnPointX;

    Vector3 objectRunDirection;
    Vector3 objectVelocity;
    Vector3 spawnPoint;
    Vector3 firstObjectsSpawnPosition;

    public GameObject[] trees;
    public GameObject[] rocks;

    public GameObject[] treesRef;
    public GameObject[] rocksRef;
    
    public GameObject firstEnvObject;

    GameObject objectToSpawn;
    GameObject newSpawnedObject;

    public static Stopwatch objectSpawnStopwatch;

    void Start()
    {   
        currentSecond = 0f;
        objectRunDirection = Vector3.back;
        objectVelocity = objectRunDirection * runningSpeed;
        amountOfObjectsToSpawnAtStart = 30;
        
        spawnTime = 1f;
        objectSpawnStopwatch = new Stopwatch();


        //CHECK DISTANCE AND MOVE OBJECTS FROM EACH OTHER IF TOO CLOSE
        for (int i = 0; i < amountOfObjectsToSpawnAtStart; i++)
        {
            float distanceBetweenTwo;
            firstObjectsSpawnPosition = new Vector3(GenerateSpawnPointX(),-0.1f,Random.Range(0,100));
            firstEnvObject = Instantiate(PickPrefab(),firstObjectsSpawnPosition,Quaternion.identity);
            firstEnvObject.transform.localScale = Vector3.one * Random.Range(0.7f,1.3f);
            firstSpawnedObjects.Add(firstEnvObject);

            //move object if it is very close to another object
            if (i > 0 && i < amountOfObjectsToSpawnAtStart-1)
            {
                distanceBetweenTwo = CalculateDistanceBetweenObjects(i-1);
                if (distanceBetweenTwo < 3)
                {
                    if (firstEnvObject.transform.position.x < 0)
                    {
                    firstEnvObject.transform.Translate(Random.Range(-6,-3),0,0);
                    }
                    else 
                    {
                    firstEnvObject.transform.Translate(Random.Range(3,6),0,0);
                    }
                }
                distanceBetweenTwo = CalculateDistanceBetweenObjects(i-1);

            }
        }
    }

    void Update()
    {
        // PICK PREFAB TO SPAWN AND SPAWN IT
        objectToSpawn = PickPrefab();
        SpawnAndRun();
        amountOfObjectsToSpawn = Random.Range(1,5);

        //GET ALL THE SPAWNED OBJECTS
        treesRef = GameObject.FindGameObjectsWithTag("tree");
        rocksRef = GameObject.FindGameObjectsWithTag("rock");


        //DESTROY IF OUT OF SCREEN
        foreach (GameObject tree in treesRef)
        {
            tree.transform.Translate(transform.TransformDirection(objectVelocity) * Time.deltaTime);
            if (tree.transform.position.z < -5f && tree != null) Destroy(tree);
        }

        foreach (GameObject rock in rocksRef)
        {
            rock.transform.Translate(transform.TransformDirection(objectVelocity) * Time.deltaTime);
            if (rock.transform.position.z < -5f && rock != null) Destroy(rock);
        }

    }

    void SpawnAndRun()
    {
        if (objectSpawnStopwatch.Elapsed.TotalSeconds == 0) objectSpawnStopwatch.Start();
        
        if (currentSecond + spawnTime < objectSpawnStopwatch.Elapsed.TotalSeconds)
        {
            for (int i = 0; i <= amountOfObjectsToSpawn; i++)
            {
                spawnPoint = new Vector3(GenerateSpawnPointX(),-0.1f,100);
                newSpawnedObject = Instantiate(objectToSpawn,spawnPoint,Quaternion.Euler(0,0,0));
                newSpawnedObject.transform.localScale = Vector3.one * Random.Range(0.7f,1.3f);
            }
            currentSecond += spawnTime;
        }
    }

    float GenerateSpawnPointX()
    {
        if (Random.value < 0.5f)
        {
            spawnPointX = Random.Range(rangeMin,rangeMax);    
        }
        else
        {
            spawnPointX = Random.Range(-rangeMax,-rangeMin);    
        }
        return spawnPointX;
    }

    GameObject PickPrefab()
    {
        GameObject prefabToSpawn;

        if (Random.value < 0.75f)
        {
            int randomIndex = Random.Range(0,trees.Length);
            prefabToSpawn = trees[randomIndex];    
        }

        else
        {
            int randomIndex = Random.Range(0,rocks.Length);
            prefabToSpawn = rocks[randomIndex];    
        }

        return prefabToSpawn;
    }

    float CalculateDistanceBetweenObjects(int listItemIndex)
    {   
        float distanceBetweenObjects;
        float xSqDiff = Mathf.Pow(firstSpawnedObjects[listItemIndex].transform.position.x - firstSpawnedObjects[listItemIndex + 1].transform.position.x,2);
        float zSqDiff = Mathf.Pow(firstSpawnedObjects[listItemIndex].transform.position.z - firstSpawnedObjects[listItemIndex + 1].transform.position.z,2);
        return distanceBetweenObjects = Mathf.Sqrt(xSqDiff + zSqDiff);
    }
    
}
