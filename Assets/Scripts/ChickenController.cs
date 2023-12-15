using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    // float chickenVelocity = 3f;
    Rigidbody chickenRigidbody;

    public Camera mainCamera;

    float distanceFromFingerToBird;
    float speedAdjustment;
    public float chickenSpeed = 0.0023f;

    private Touch touch;

    Vector3 speed;
    Vector3 targetPosition;
    Vector3 ChickenScreenPointPosition;

    void Start()
    {
        chickenRigidbody = GetComponent<Rigidbody>();
        distanceFromFingerToBird = 75;
        speedAdjustment = 35;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            ChickenScreenPointPosition = mainCamera.WorldToScreenPoint(transform.position);

            Ray chickenPositionRay = mainCamera.ScreenPointToRay(touch.position);
            RaycastHit hitInfo;

            if (Physics.Raycast (chickenPositionRay, out hitInfo,Mathf.Infinity))
            {
                targetPosition = mainCamera.WorldToScreenPoint(new Vector3(hitInfo.point.x,0,0));
            }

            if(touch.phase == TouchPhase.Moved)
            {
                //// SPOSOB NR 1
                // if (targetPosition.x - ChickenScreenPointPosition.x > 50)
                // {
                //     chickenRigidbody.velocity = new Vector3(speed,chickenRigidbody.velocity.y,chickenRigidbody.velocity.z); 
                // }
                // else if (targetPosition.x - ChickenScreenPointPosition.x < -50) 
                // {
                //     chickenRigidbody.velocity = new Vector3(-speed,chickenRigidbody.velocity.y,chickenRigidbody.velocity.z); 
                // }
                // else 
                // {
                //     chickenRigidbody.velocity = Vector3.zero;
                // }
                //// SPOSOB NR 1
                
                //// SPOSOB NR 2
                // if (targetPosition.x - ChickenScreenPointPosition.x > distanceFromFingerToBird)
                // {
                //     chickenRigidbody.velocity = new Vector3(speed.x,chickenRigidbody.velocity.y,chickenRigidbody.velocity.z); 
                // }
                // else if (targetPosition.x - ChickenScreenPointPosition.x < -distanceFromFingerToBird)
                // {
                //     chickenRigidbody.velocity = new Vector3(-speed.x,chickenRigidbody.velocity.y,chickenRigidbody.velocity.z); 
                // }
                // else 
                // {
                //     chickenRigidbody.velocity = Vector3.zero;
                // }
                //// SPOSOB NR 2

                speed = CalculateChickenSpeed();

                //// SPOSOB NR 3
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * chickenSpeed,
                                                    transform.position.y,transform.position.z);
                //// SPOSOB NR 3

                
            }
            else if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Ended)
            {
                    chickenRigidbody.velocity = Vector3.zero;

            }
        }

        if (transform.position.x <= -1.19f)
        {
            transform.position = new Vector3(-1.19f,transform.position.y,transform.position.z);
        }
        else if (transform.position.x >= 1.19f)
        {
            transform.position = new Vector3(1.19f,transform.position.y,transform.position.z);
        }
    }

    Vector3 CalculateChickenSpeed()
    {
        float chickenSpeedX;

        float timeToReachFinger = 0.2f;
        float distanceChickenToFinger = (Mathf.Abs(targetPosition.x - ChickenScreenPointPosition.x));

        chickenSpeedX = distanceChickenToFinger/timeToReachFinger;
        Vector3 chickenSpeed = new Vector3(chickenSpeedX/speedAdjustment,0,0);

        return chickenSpeed;
    }
}
