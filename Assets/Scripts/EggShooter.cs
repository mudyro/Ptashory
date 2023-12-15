using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Diagnostics;

public class EggShooter : MonoBehaviour
{
    public GameObject commonEggPrefab;
    public GameObject rareEggPrefab;
    public GameObject legendaryEggPrefab;
    GameObject newEggPrefab;
    GameObject chickenObject;

    public float shootingSpeed;
    int eggsLeft;
    int eggsLimit;

    Vector3 eggDirection;
    Vector3 eggVelocity;

    public Stopwatch eggIncubationTimer;
    
    public bool isEggAvaiable;
    
    void Start()
    {
        shootingSpeed = 30f;
        eggDirection = Vector3.forward;
        eggVelocity = eggDirection * shootingSpeed;
        chickenObject = GameObject.Find((PlayerPrefs.GetString("EquippedBird","01_Sparrow").Substring(0,PlayerPrefs.GetString("EquippedBird").Length -11)));
        eggsLeft = 1;
        isEggAvaiable = true;
        eggsLimit = 2;
        eggIncubationTimer = new Stopwatch();
        eggIncubationTimer.Start();

    }

    void Update()
    {
        EggIncubator();
        CheckIfEggsAreAvailable();
    }

    // On click event, no longer using it
    // public void OnTouchShoot(InputAction.CallbackContext context)
    // {
    //         if (eggsLeft > 0)
    //         {
    //             SpawnAndShoot();
    //         }
    //         else 
    //         {
    //             UnityEngine.Debug.Log("No eggs left! Wait untill your bird lays an egg.");
    //         }
    // }

    public void SpawnAndShoot()
    {
            if (eggsLeft > 0)
            {
                if (PlayerPrefs.GetString("EquippedEgg","03_CommonEggIcon(Clone)") == "03_CommonEggIcon(Clone)")
                { //spawn and give velocity to egg 
                    newEggPrefab = Instantiate(commonEggPrefab,chickenObject.transform.position + Vector3.up * 0.5f,Quaternion.identity);
                    Rigidbody eggRigidBody = newEggPrefab.GetComponent<Rigidbody>();
                    eggRigidBody.velocity = eggVelocity;
                    eggsLeft -= 1;
                }
                else if (PlayerPrefs.GetString("EquippedEgg","03_CommonEggIcon(Clone)") == "03_RareEggIcon(Clone)")
                {
                    newEggPrefab = Instantiate(rareEggPrefab,chickenObject.transform.position + Vector3.up * 0.5f,Quaternion.identity);
                    Rigidbody eggRigidBody = newEggPrefab.GetComponent<Rigidbody>();
                    eggRigidBody.velocity = eggVelocity;
                    eggsLeft -= 1;
                }
                else if (PlayerPrefs.GetString("EquippedEgg","03_CommonEggIcon(Clone)") == "03_LegEggIcon(Clone)")
                {
                    newEggPrefab = Instantiate(legendaryEggPrefab,chickenObject.transform.position + Vector3.up * 0.5f,Quaternion.identity);
                    Rigidbody eggRigidBody = newEggPrefab.GetComponent<Rigidbody>();
                    eggRigidBody.velocity = eggVelocity;
                    eggsLeft -= 1;
                }
            }
    }

    void CheckIfEggsAreAvailable()
    {
        if (eggsLeft > 0)
            {
                isEggAvaiable = true;
            }
        else
            {
                isEggAvaiable = false;
            }
    }

    void EggIncubator()
    {
        
     // upper the egg amount each 10 seconds with max of (eggsLimit) eggs.
        if (eggIncubationTimer.Elapsed.Seconds > 10)
        {
            if (eggsLimit < 3) eggsLeft += 1;
            eggIncubationTimer.Reset();
            eggIncubationTimer.Start();
        }
    }
}
