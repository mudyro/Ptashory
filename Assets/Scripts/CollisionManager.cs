using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // public GameObject chickenToIgnore;
    public GameObject crackedEgg;

    Collider bulletCollider; 
    
    public int enemyLivesLeft;
    

    void Update()
    {
        if (transform.position.z > 35f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider triggerCollider)
    {
        //check if the colliding object is enemy and take one life of it and destroy the bullet.
        bulletCollider = GetComponent<Collider>();

        if (triggerCollider.gameObject.tag == "Enemy")
        {
            //get reference to enemy game object
            GameObject enemyGameObject = triggerCollider.gameObject;
            //get reference to enemy script
            Enemy enemyScript = enemyGameObject.GetComponent<Enemy>();
            
            if (enemyScript == null)
            {
                //do nothing
            }
            else if(gameObject.tag == "Egg")
            {
                enemyScript.enemyLivesLeft -= 3;
            }
            else if(gameObject.tag == "RareEgg")
            {
                Instantiate(crackedEgg,gameObject.transform.position- new Vector3(0,0.45f,0),Quaternion.identity);
                enemyScript.enemyLivesLeft -= 1;
            }
            else if(gameObject.tag == "LegEgg")
            {
                enemyScript.enemyLivesLeft = 0;
            }
            else if(gameObject.tag == "Seed")
            {
                enemyScript.enemyLivesLeft -= 1;
            }

            Destroy(gameObject);
        }
        

    }
}
