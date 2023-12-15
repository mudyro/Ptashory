using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreUpdater : MonoBehaviour
{
    public TMP_Text firstHS;
    public TMP_Text secondHS;
    public TMP_Text thirdHS;
    public TMP_Text fourthHS;
    public TMP_Text fifthHS;
    
    public TMP_Text firstHSDate;
    public TMP_Text secondHSDate;
    public TMP_Text thirdHSDate;
    public TMP_Text fourthHSDate;
    public TMP_Text fifthHSDate;

    void Start()
    {
        firstHS.text = PlayerPrefs.GetInt("highScore1",0).ToString();
        secondHS.text = PlayerPrefs.GetInt("highScore2",0).ToString();
        thirdHS.text = PlayerPrefs.GetInt("highScore3",0).ToString();
        fourthHS.text = PlayerPrefs.GetInt("highScore4",0).ToString();
        fifthHS.text = PlayerPrefs.GetInt("highScore5",0).ToString();

        firstHSDate.text = PlayerPrefs.GetString("highScore1Date","Date Uknown");
        secondHSDate.text = PlayerPrefs.GetString("highScore2Date","Date Uknown");
        thirdHSDate.text = PlayerPrefs.GetString("highScore3Date","Date Uknown");
        fourthHSDate.text = PlayerPrefs.GetString("highScore4Date","Date Uknown");
        fifthHSDate.text = PlayerPrefs.GetString("highScore5Date","Date Uknown");
    }

    void Update()
    {
        
    }
}
