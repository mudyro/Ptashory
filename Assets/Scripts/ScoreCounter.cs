using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{

    public static int score;
    public static int highScore;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    void Start()
    {
        scoreText = GameObject.Find("scoreText").GetComponent<TMP_Text>();
        highScoreText = GameObject.Find("highScoreText").GetComponent<TMP_Text>();
        highScore = 0;
    }

    void Update()
    {
        scoreText.text = "SCORE: " + score;
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("highScore1",score);

        if (highScore < score)
            {
                highScore = score;
            }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            score = 0;
            if (EnemySpeedCalculator.roundTimer != null && EnemySpeedCalculator.roundTimer.Elapsed.TotalSeconds > 0)
            {
                EnemySpeedCalculator.roundTimer.Reset();
            }
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
