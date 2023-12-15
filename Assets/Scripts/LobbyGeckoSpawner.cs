using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyGeckoSpawner : MonoBehaviour
{
    public float geckoSpeed;
    Rigidbody geckoRigidbody;
    Vector3 geckoAngle;

    void Start()
    {   
        
        geckoAngle = new Vector3(Mathf.Cos((transform.localRotation.eulerAngles.y-90)*Mathf.Deg2Rad),0,
        Mathf.Sin((transform.localRotation.eulerAngles.y-90)*Mathf.Deg2Rad));
        geckoSpeed = 2f;

        geckoRigidbody = gameObject.GetComponent<Rigidbody>();
        geckoRigidbody.velocity = new Vector3(geckoSpeed * geckoAngle.x, 0, -geckoSpeed * geckoAngle.z);
        
        
    }

    void Update()
    {
        if (transform.localPosition.x >= 8.8f)
        {
            transform.rotation = Quaternion.Euler(0,230,0);
            geckoRigidbody.velocity = new Vector3(-geckoRigidbody.velocity.x, 0, geckoRigidbody.velocity.z);
        }
        else if (transform.localPosition.x <= -9 && transform.localPosition.z < 0)
        {
            geckoRigidbody.velocity = new Vector3(geckoSpeed * geckoAngle.x, 0, -geckoSpeed * geckoAngle.z);
            transform.rotation = Quaternion.Euler(0,130,0);
            transform.localPosition = new Vector3(-15.82f,-1,16.65f);
        }
        
    }
}
