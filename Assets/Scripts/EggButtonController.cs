using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggButtonController : MonoBehaviour
{
    Image image;
    EggShooter eggShooter;
    Color greenColor;
    bool previousStateOfEggAvaiability;
    float elapsedTime;

    void Start()
    {
        image = GetComponent<Image>();
        eggShooter = GameObject.Find("EggSpawner").GetComponent<EggShooter>();
        greenColor = new Color(0.5f,1f,0.25f);

        
    }

    void Update()
    {
        UpdateEggButtonVisuals();
    }

    void UpdateEggButtonVisuals()
    {
        if (!eggShooter.isEggAvaiable)
        {
            image.color = Color.red;
            float duration = 10f; // 10 seconds to fill the circle
            elapsedTime = (float)eggShooter.eggIncubationTimer.Elapsed.TotalSeconds;
            image.fillAmount = elapsedTime / duration;
        }

        else
        {
            image.fillAmount = 1f;
            image.color = greenColor;
        }
    }
}
