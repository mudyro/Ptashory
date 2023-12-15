using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class EquipmentSpawner : MonoBehaviour
{
    public Transform ItemContent;
    public Transform birdParent;
    public Transform seedParent;
    public Transform eggParent;

    string itemName;
    string itemIndex;
    string playerPrefsValueName;
    public static string[] allPossibleObjetsToSpawn = new string[] {"01_CommonBirdIcon","01_RareBirdIcon","01_LegBirdIcon","02_CommonSeedIcon","02_RareSeedIcon",
    "02_LegSeedIcon","03_CommonEggIcon","03_RareEggIcon","03_LegEggIcon"};

    string EquippedBird = "";
    string EquippedSeed = "";
    string EquippedEgg = "";
    PlayerSpawner playerSpawner;

    List<string> keysToCheckBeforeDeleting;

     void Start()
    {
        
        // RESET PLAYERPREFS ITEM SLOTS
        // PlayerPrefs.SetInt("ItemsSaved",0);
        // for (int i= 0; i <= 29; i++)
        // {
        //     PlayerPrefs.SetString("item"+i.ToString(),"EmptyItemSlot");
        // }
    }

    public void  SpawnEquipement()
    {
        
        

        EquippedBird = PlayerPrefs.GetString("EquippedBird","EmptyItemSlot").Substring(0,PlayerPrefs.GetString("EquippedBird","EmptyItemSlot").Length - 7);
        EquippedSeed = PlayerPrefs.GetString("EquippedSeed","EmptyItemSlot").Substring(0,PlayerPrefs.GetString("EquippedSeed","EmptyItemSlot").Length - 7);
        EquippedEgg = PlayerPrefs.GetString("EquippedEgg","EmptyItemSlot").Substring(0,PlayerPrefs.GetString("EquippedEgg","EmptyItemSlot").Length - 7);

        //Create default equipment 
        
        //Spawn not equipped items
        if (PlayerPrefs.GetInt("ItemsSaved",0) > 0)
        {
            int equipmentPlaceCounter = 0;
            GameObject[] EquipementList = new GameObject[PlayerPrefs.GetInt("ItemsSaved",0)];
            for (int i = 0; i < 30; i++)
            {       
                    playerPrefsValueName = (PlayerPrefs.GetString("item"+i.ToString(),"EmptyItemSlot")).Substring(0,PlayerPrefs.GetString("item"+i.ToString(),"EmptyItemSlot").Length - 7);
                    if (Array.IndexOf(allPossibleObjetsToSpawn, playerPrefsValueName) != -1)
                    {
                        EquipementList[equipmentPlaceCounter] = GameObject.Find(playerPrefsValueName);
                        Instantiate(EquipementList[equipmentPlaceCounter],ItemContent);
                        equipmentPlaceCounter ++;
                    }
            }
        }

        //Spawn equipped items
        if (Array.IndexOf(allPossibleObjetsToSpawn,EquippedBird) != -1)
        {
            GameObject birdToSpawn = GameObject.Find(EquippedBird);
            GameObject newBird = Instantiate(birdToSpawn,birdParent);
            
            
            newBird.transform.localPosition = Vector3.zero;
            
            GameObject newBirdButton = newBird.transform.GetChild(1).gameObject;
            EquipItem equipItem = newBirdButton.GetComponent<EquipItem>();
            equipItem.doNotDeleteItem = true;
            equipItem.ChangeParentOfTheIcon();
        }
        if (Array.IndexOf(allPossibleObjetsToSpawn,EquippedSeed) != -1)
        {
            GameObject seedToSpawn = GameObject.Find(EquippedSeed);
            GameObject newSeed = Instantiate(seedToSpawn,seedParent);
        
            newSeed.transform.localPosition = Vector3.zero;

            GameObject newSeedButton = newSeed.transform.GetChild(1).gameObject;
            EquipItem equipItemOne = newSeedButton.GetComponent<EquipItem>();
            equipItemOne.doNotDeleteItem = true;
            equipItemOne.ChangeParentOfTheIcon();

        }
        if (Array.IndexOf(allPossibleObjetsToSpawn,EquippedEgg) != -1)
        {
            GameObject eggToSpawn = GameObject.Find(EquippedEgg);
            GameObject newEgg = Instantiate(eggToSpawn,eggParent);
            newEgg.transform.localPosition = Vector3.zero;

            GameObject newEggButton = newEgg.transform.GetChild(1).gameObject;
            EquipItem equipItemTwo = newEggButton.GetComponent<EquipItem>();
            equipItemTwo.doNotDeleteItem = true;
            equipItemTwo.ChangeParentOfTheIcon();
        }

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 5)
        {
           SpawnEquipement();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
