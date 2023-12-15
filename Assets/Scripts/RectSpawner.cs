using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Linq;
using System;

public class RectSpawner : MonoBehaviour
{
    public Transform firstRowContainer;
    public Transform secondRowContainer;
    public Transform thridRowContainer;

    public GameObject rectPrefab;
    GameObject randomItem;

    public GameObject rareBirdPrefab;
    public GameObject commonBirdPrefab;
    public GameObject legendaryBirdPrefab;

    public GameObject rareSeedPrefab;
    public GameObject commonSeedPrefab;
    public GameObject legendarySeedPrefab;

    public GameObject rareEggPrefab;
    public GameObject commonEggPrefab;
    public GameObject legendaryEggPrefab;


    public GameObject drawnBird;
    public GameObject drawnSeed;
    public GameObject drawnEgg;

    public static GameObject[] LotteryPrizes;
    GameObject[] birdLotteryStorage;
    GameObject[] seedLotteryStorage;
    GameObject[] eggLotteryStorage;
    GameObject[][] lotteryStorage;

    GameObject[] allRects;
    GameObject newSpawnedRect;

    Transform[] containers;
    RectTransform[] allRectTrans;

    Vector2 scrollingSpeed;

    public float startScrollingSpeed;
    public float endScrollingSpeed;
    public float acceleration;
    float screenLimitY = -1440;
    float newScrollingSpeed;
    
    int mouseClicks;
    int numberOfLotteriesDone;
    public static int itemsSavedHelper;


    bool endPhaseStart;
    bool reachedPositionZero;
    bool lotteryRunning;
    bool prizesDrawn;
    
    
    Stopwatch endPhaseTimer;

    Stopwatch lotteryTimer;

    Rigidbody2D emptyItemRectRB;

    void Start()
    {
        lotteryTimer = new Stopwatch();

        birdLotteryStorage = new GameObject[10];
        seedLotteryStorage = new GameObject[10];
        eggLotteryStorage = new GameObject[10];

        //legends
        birdLotteryStorage[0] = legendaryBirdPrefab;
        seedLotteryStorage[0] = legendarySeedPrefab;
        eggLotteryStorage[0] = legendaryEggPrefab;

        //commons
        for (int i = 1; i < 10; i++)
        {
            birdLotteryStorage[i] = commonBirdPrefab;
            eggLotteryStorage[i] = commonEggPrefab;
            seedLotteryStorage[i] = commonSeedPrefab;
        }

        //rares
        for (int i = 1; i < 4; i++)
        {
            birdLotteryStorage[i] = rareBirdPrefab;
            seedLotteryStorage[i] = rareSeedPrefab;
            eggLotteryStorage[i] = rareEggPrefab;
        }

        lotteryStorage = new GameObject[][] {birdLotteryStorage,seedLotteryStorage,eggLotteryStorage};
        
        scrollingSpeed = new Vector2(0,-0.1f);
        containers = new Transform[] {firstRowContainer,secondRowContainer,thridRowContainer};
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0 ; i < 40; i++)
            {
                if  (j == 0)
                {
                    SpawnNewItemSlot(-360 + j * 360,- 360 * 4 + i * 360,j,lotteryStorage[j][Mathf.RoundToInt(UnityEngine.Random.Range(0,8.9f))]);
                }
                else if (j == 1)
                {
                    SpawnNewItemSlot(-360 + j * 360, 360 * 4 - i * 360,j,lotteryStorage[j][Mathf.RoundToInt(UnityEngine.Random.Range(0,8.9f))]);
                }
                else if (j == 2)
                {
                    SpawnNewItemSlot(-360 + j * 360,- 360 * 4 + i * 360,j,lotteryStorage[j][Mathf.RoundToInt(UnityEngine.Random.Range(0,8.9f))]);
                }
            }
        }
    }

    void Update()
    {
        if (lotteryRunning)
        {
            Lottery();
        }
    }

    void Lottery()
    {
        lotteryTimer.Start();
        //Find all ItemSlots and get its rectTrasform
        List<GameObject> birds = GameObject.FindGameObjectsWithTag("BirdItem").ToList();
        List<GameObject> eggs = GameObject.FindGameObjectsWithTag("EggItem").ToList();
        List<GameObject> seeds = GameObject.FindGameObjectsWithTag("SeedItem").ToList();

        List<GameObject> allRects = new List<GameObject>();

        allRects.AddRange(birds);
        allRects.AddRange(eggs);
        allRects.AddRange(seeds);

        foreach (GameObject rect in allRects)
        {
            RectTransform rectRectTrasform = rect.GetComponent<RectTransform>();
            Rigidbody2D rectRigidBody = rect.GetComponent<Rigidbody2D>();

            //check its parent and move
            if (rectRectTrasform.parent.name == "firstRow")
            {
                //destroy the object when it leaves the screen and spawn new item slot
                if (rectRectTrasform.anchoredPosition.y < screenLimitY)
                {
                    Destroy(rect);        
                    reachedPositionZero = true;
                }

                rectRigidBody.velocity = new Vector2(0,-CalculateScrollingSpeed());

            }

            else if (rectRectTrasform.parent.name == "secondRow")
            {
                //destroy the object when it leaves the screen and spawn new item slot
                if (rectRectTrasform.anchoredPosition.y > -screenLimitY)
                {
                    Destroy(rect);     
                    reachedPositionZero = true; 
                }

                rectRigidBody.velocity = new Vector2(0,CalculateScrollingSpeed());
            }

            else if (rectRectTrasform.parent.name == "thirdRow")
            {
                //destroy the object when it leaves the screen and spawn new item slot
                if (rectRectTrasform.anchoredPosition.y < screenLimitY)
                {
                    Destroy(rect);   
                    reachedPositionZero = true;
                }

                rectRigidBody.velocity = new Vector2(0,-CalculateScrollingSpeed());
            }

            if (endPhaseStart && reachedPositionZero)
            {
                rectRigidBody.velocity = Vector2.zero;
                lotteryTimer.Stop();
                lotteryTimer.Reset();

                if (numberOfLotteriesDone == 0)
                {
                    prizesDrawn = true;
                }
            }

            else
            {
                reachedPositionZero = false;
            }

            if (prizesDrawn)
            {
                DrawThePrizes();
                SaveItemsInPlayerPrefs();
                numberOfLotteriesDone++;
            }
        }
    }   

    void SpawnNewItemSlot(float itemSlotPositionX,float itemSlotPositionY, int whichRow, GameObject iconPrefab)
    {
        GameObject emptyItemRect = Instantiate(iconPrefab, containers[whichRow]);
        RectTransform rectTransform = emptyItemRect.GetComponent<RectTransform>();
        Rigidbody2D emptyItemRectRB = emptyItemRect.GetComponent<Rigidbody2D>();
        rectTransform.anchoredPosition = new Vector2(itemSlotPositionX,itemSlotPositionY);
        rectTransform.sizeDelta = new Vector2(340,340);
    }

    float CalculateScrollingSpeed()
    {
            if(startScrollingSpeed - lotteryTimer.Elapsed.TotalSeconds * acceleration > endScrollingSpeed)
        {
            newScrollingSpeed = startScrollingSpeed - (float)lotteryTimer.Elapsed.TotalSeconds * acceleration;
            return newScrollingSpeed;
        }
        else
        {
            endPhaseStart = true;
            return endScrollingSpeed;
        }
    }

    public void StartLottery()
    {
        lotteryRunning = true;
    }

    public void DrawThePrizes()
    {   
        List<GameObject> birds = GameObject.FindGameObjectsWithTag("BirdItem").ToList();
        List<GameObject> eggs = GameObject.FindGameObjectsWithTag("EggItem").ToList();
        List<GameObject> seeds = GameObject.FindGameObjectsWithTag("SeedItem").ToList();

        List<GameObject> allItems = new List<GameObject>();

        allItems.AddRange(birds);
        allItems.AddRange(eggs);
        allItems.AddRange(seeds);

        LotteryPrizes = new GameObject[3];
        float[] closestDistance = new float[3]{float.PositiveInfinity,float.PositiveInfinity,float.PositiveInfinity};

        float distance;

        foreach (GameObject item in allItems)
        {
            for (int i=-1 ; i<2 ; i++) 
            {
                distance = Vector3.Distance(item.transform.position,Vector3.zero + Vector3.right * 360 * i);
                if (closestDistance[i+1] > distance)
                {
                    closestDistance[i+1] = distance;
                    LotteryPrizes[i+1] = item;                    
                }
            }
        }
        prizesDrawn = false;
    }

    public void SaveItemsInPlayerPrefs()
    {
        foreach (GameObject prize in LotteryPrizes)
        {
            int EmptyItemIndex = 0;
            bool isSaved = false;

            while (!isSaved)
            {
                int playerPrefsValueNameLenght = (PlayerPrefs.GetString("item"+EmptyItemIndex.ToString(),"EmptyItemSlot")).Length;
                string playerPrefsValueName = (PlayerPrefs.GetString("item" + EmptyItemIndex.ToString(),"EmptyItemSlot")).Substring(0,playerPrefsValueNameLenght - 7); 
                

                if (Array.IndexOf(EquipmentSpawner.allPossibleObjetsToSpawn, playerPrefsValueName) == -1)
                {
                    PlayerPrefs.SetString("item" + EmptyItemIndex.ToString(),prize.name);
                    EmptyItemIndex++ ;
                    ItemsSavedAddItem();
                    isSaved = true;
                 
                }
                else if (EmptyItemIndex >= 29)
                {
                    isSaved = true;
                }
                else 
                {
                    EmptyItemIndex++;
                }
            }
        }
    }

    public static void ItemsSavedAddItem()
    {
        itemsSavedHelper = PlayerPrefs.GetInt("ItemsSaved",0); 
        itemsSavedHelper ++;
        PlayerPrefs.SetInt("ItemsSaved",itemsSavedHelper);
    }

    public static void ItemsSavedDeleteItem()
    {
        itemsSavedHelper = PlayerPrefs.GetInt("ItemsSaved",0); 
        itemsSavedHelper --;
        PlayerPrefs.SetInt("ItemsSaved",itemsSavedHelper);
    }

}
