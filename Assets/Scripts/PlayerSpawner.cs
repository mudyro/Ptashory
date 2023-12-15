using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    public Dictionary <string,GameObject> BirdToSpawn;

    public GameObject Sparrow;
    public GameObject Pudu;
    public GameObject Muskat;
    GameObject player;

    ChickenController playerController;

    public GameObject[] possibleBirdGameObjects;

    public string currentEquippedBirdName;

    Scene currentScene;
    

    void Start()
    {
        possibleBirdGameObjects = new GameObject[] {Sparrow,Pudu,Muskat};
        currentScene = SceneManager.GetActiveScene();
        GetNameOfPlayerBirdFromPlayerPrefs();

        if (currentScene.buildIndex == 1)
        {
            foreach (GameObject bird in possibleBirdGameObjects)
            {
                if (bird.name == currentEquippedBirdName)
                {
                    player = Instantiate(bird,Vector3.zero,Quaternion.identity);
                }
            }
            player.name = player.name.Substring(0,player.name.Length - 7);
            playerController = player.GetComponent<ChickenController>();
            playerController.mainCamera = Camera.main;
        }
    }

    public void GetNameOfPlayerBirdFromPlayerPrefs()
    {
        currentEquippedBirdName = PlayerPrefs.GetString("EquippedBird","01_CommonBirdIcon(Clone)").Substring(0,PlayerPrefs.GetString("EquippedBird","01_CommonBirdIcon(Clone)").Length - 7);
        if (currentEquippedBirdName == "EmptyI")
        {
            currentEquippedBirdName = "01_CommonBirdIcon";
        }

        if ((Array.IndexOf(EquipmentSpawner.allPossibleObjetsToSpawn,currentEquippedBirdName)) != -1)
        {
            currentEquippedBirdName = currentEquippedBirdName.Substring(0, currentEquippedBirdName.Length - 4);
        }
    }
}
