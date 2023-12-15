using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TMP_Text scoreTextGO;

    void Update()
    {
        scoreTextGO.text = ScoreCounter.score.ToString();
    }
}
