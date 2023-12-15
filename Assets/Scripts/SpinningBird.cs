using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBird : MonoBehaviour
{

    public float rotationSpeed;


    void Start()
    {
        rotationSpeed = 80f;  
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0,rotationSpeed * Time.time,0);
    }
}
