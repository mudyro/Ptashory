using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class ExplosionCleaner : MonoBehaviour
{
    Stopwatch timer;
    void Start()
    {  
        timer = new Stopwatch();
        timer.Start();
    }

    void Update()
    {
        if (timer.Elapsed.TotalSeconds > 2)
        {
            Destroy(gameObject);
            timer.Stop();
            timer.Reset();
        }
    }
}
