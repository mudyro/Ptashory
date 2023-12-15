using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinSeedShot : MonoBehaviour
{

    Rigidbody seedRigidBody;
    SeedShooter seedShooter;
    float speedOnX;
    float amplitude = 4;

    void Start()
    {
        seedRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CalculateAndChangeSinSeedShotSpeed();
    }

    void CalculateAndChangeSinSeedShotSpeed()
    {
        if (gameObject != null && gameObject.name == "SinSeedTwo(Clone)")
        {
            speedOnX = Mathf.Sin((float)SeedShooter.spawnTimer.Elapsed.TotalSeconds*Mathf.PI*2) * amplitude;
            seedRigidBody.velocity =  new Vector3(speedOnX,0,seedRigidBody.velocity.z);
        }
        else if (gameObject != null && gameObject.name == "SinSeedOne(Clone)")
        {
            speedOnX = Mathf.Sin((float)SeedShooter.spawnTimer.Elapsed.TotalSeconds*Mathf.PI*2) * amplitude;
            seedRigidBody.velocity =  new Vector3(-speedOnX,0,seedRigidBody.velocity.z);
        }
    }
}
