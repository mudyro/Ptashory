
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PauseGame : MonoBehaviour
{

    GameObject eggSpawner;
    GameObject seedSpawner;
    GameObject enemySpawner;
    ChickenController duckControllScript;
    GameObject pauseScreen;
    GameObject[] enemies;
    GameObject tapToPauseText;
    GameObject canvas;
    GameObject envSpawner;
    
    private ChickenController chickenController;

    int taps;
    bool gamePaused = false;
    //game paused image

    void Start()
    {
        eggSpawner = GameObject.Find("EggSpawner");
        seedSpawner = GameObject.Find("SeedSpawner");
        enemySpawner = GameObject.Find("EnemySpawner");
        canvas = GameObject.Find("Canvas");
        tapToPauseText = GameObject.Find("PauseText");
        envSpawner = GameObject.Find("EnvironmentSpawner");

        pauseScreen = canvas.transform.GetChild(0).gameObject;
        duckControllScript = GameObject.Find((PlayerPrefs.GetString("EquippedBird","01_CommonBirdIcon(Clone)").Substring(0,PlayerPrefs.GetString("EquippedBird").Length -11))).GetComponent<ChickenController>();
    }

    void Update()
    {
        if (duckControllScript == null)
        {

            duckControllScript = GameObject.Find((PlayerPrefs.GetString("EquippedBird","01_CommonBirdIcon(Clone)").Substring(0,PlayerPrefs.GetString("EquippedBird").Length -11))).GetComponent<ChickenController>();
        }
    }

    public void OnTrippleTapPause(InputAction.CallbackContext context)
    {
        if (!gamePaused)
        {
            Time.timeScale = 0;
            gamePaused = true;
            eggSpawner.SetActive(false);
            EnemySpawner.enemySpawnStopwatch.Stop();
            SeedShooter.spawnTimer.Stop();
            enemySpawner.SetActive(false);
            duckControllScript.enabled = false;
            pauseScreen.SetActive(true);
            tapToPauseText.SetActive(false);
            // envSpawner.SetActive(false);

            //turn on game paused image
        }
        else if (gamePaused)
        {
            Time.timeScale = 1;
            gamePaused = false;
            eggSpawner.SetActive(true);
            EnemySpawner.enemySpawnStopwatch.Start();
            SeedShooter.spawnTimer.Start();
            enemySpawner.SetActive(true);
            duckControllScript.enabled = true;
            pauseScreen.SetActive(false);
            tapToPauseText.SetActive(true);
            // envSpawner.SetActive(true);

            //turn off game paused image
        }
    }
}
