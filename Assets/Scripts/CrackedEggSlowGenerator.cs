using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedEggSlowGenerator : MonoBehaviour
{
    Collider eggCollider;

    GameObject enemy;
    Rigidbody enemyRigidBody;
    // EnemySpawner enemySpawner;
    Vector3 enemyOriginalSpeed;

    void Start()
    {
        // enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        Rigidbody eggRigidBody = gameObject.GetComponent<Rigidbody>();
        eggRigidBody.velocity = new Vector3(0,0,-4f);
    }

    void OnTriggerEnter(Collider triggerCollider)
    {
        eggCollider = GetComponent<Collider>();

        if (triggerCollider.gameObject.tag == "Enemy")
        {
            enemy = triggerCollider.gameObject;
            enemyRigidBody = enemy.GetComponent<Rigidbody>();
            enemyOriginalSpeed = enemyRigidBody.velocity;
            enemyRigidBody.velocity = new Vector3(0,0,-8f);
        }
    }

    void OnTriggerExit(Collider triggerCollider)
    {
        eggCollider = GetComponent<Collider>();

        if (triggerCollider.gameObject.tag == "Enemy")
        {
            enemy = triggerCollider.gameObject;
            enemyRigidBody = enemy.GetComponent<Rigidbody>();
            enemyRigidBody.velocity = enemyOriginalSpeed;
        }
    }
}
