using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeaderBoardManager : MonoBehaviour
{
    int highScore;

    void Start()
    {
    }

    void Update()
    {
        highScore = ScoreCounter.highScore;
        SaveHighScore();

    }

     void SaveHighScore()
    {
        if (LifesLeftManager.setHightScore)
        {
            if (highScore > PlayerPrefs.GetInt("highScore1",0)) 
            {
                //update next high score (beaten one)
                PlayerPrefs.SetInt("highScore2",PlayerPrefs.GetInt("highScore1"));
                PlayerPrefs.SetString("highScore2Date",PlayerPrefs.GetString("highScore1Date"));

                PlayerPrefs.SetInt("highScore1",highScore);
                PlayerPrefs.SetString("highScore1Date",System.DateTime.Now.ToString());
                LifesLeftManager.setHightScore = false;
            }

            else if(highScore > PlayerPrefs.GetInt("highScore2",0)) 
            {
                PlayerPrefs.SetInt("highScore3",PlayerPrefs.GetInt("highScore2"));
                PlayerPrefs.SetString("highScore3Date",PlayerPrefs.GetString("highScore2Date"));
                
                PlayerPrefs.SetInt("highScore2",highScore);
                PlayerPrefs.SetString("highScore2Date",System.DateTime.Now.ToString());
                LifesLeftManager.setHightScore = false;
            }

            else if(highScore > PlayerPrefs.GetInt("highScore3",0)) 
            {
                PlayerPrefs.SetInt("highScore4",PlayerPrefs.GetInt("highScore3"));
                PlayerPrefs.SetString("highScore4Date",PlayerPrefs.GetString("highScore3Date"));
                
                PlayerPrefs.SetInt("highScore3",highScore);
                PlayerPrefs.SetString("highScore3Date",System.DateTime.Now.ToString());
                LifesLeftManager.setHightScore = false;
            }

            else if(highScore > PlayerPrefs.GetInt("highScore4",0)) 
            {
                PlayerPrefs.SetInt("highScore5",PlayerPrefs.GetInt("highScore4"));
                PlayerPrefs.SetString("highScore5Date",PlayerPrefs.GetString("highScore4Date"));

                PlayerPrefs.SetInt("highScore4",highScore);
                PlayerPrefs.SetString("highScore4Date",System.DateTime.Now.ToString());
                LifesLeftManager.setHightScore = false;
            }

            else if(highScore > PlayerPrefs.GetInt("highScore5",0)) 
            {
                PlayerPrefs.SetInt("highScore5",highScore);
                PlayerPrefs.SetString("highScore5Date",System.DateTime.Now.ToString());
                LifesLeftManager.setHightScore = false;
            }
        }
    }
}
