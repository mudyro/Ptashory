using UnityEngine;
using System.Diagnostics;

public class GradientColorCreator : MonoBehaviour
{   
    

    [Range(0.0f,1.0f)]
    public float lerpTime = 0.01f;
    float colorChangeInterval = 7.5f;

    public Color startColor;
    public Color endColor;
    public Color colorOne;
    public Color colorTwo;
    public Color colorThree;

    Stopwatch enemySpawnStopwatch;

    int nextColorIndex = 2;

    public Color[] allColors = new Color[4];

    void Start()
    {
        allColors = new Color[] {colorOne, colorTwo, colorThree};
        startColor = colorOne;
        endColor = colorTwo;
        
        enemySpawnStopwatch = new Stopwatch();
        enemySpawnStopwatch.Start();

    }

    void Update()
    {
        if (Camera.main.backgroundColor != colorThree)
        {
            lerpTime = (float)enemySpawnStopwatch.Elapsed.TotalSeconds / colorChangeInterval;
            Camera.main.backgroundColor = Color.Lerp(startColor, endColor, lerpTime);
            RenderSettings.fogColor = Camera.main.backgroundColor;
        }

        if (Camera.main.backgroundColor == endColor && Camera.main.backgroundColor != colorThree)
        {
            (startColor,endColor) = (endColor,allColors[nextColorIndex]);
            enemySpawnStopwatch.Reset();
            enemySpawnStopwatch.Start();

        }
    }
}
