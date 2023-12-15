using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int enemyLivesLeft; 
    public ParticleSystem explosionParticle;

    void Start()
    {
        if (gameObject.name == "GeckoPrefabEnemy(Clone)")
        {
            enemyLivesLeft = 1;
        }
        else if (gameObject.name == "ColobusPrefabEnemy(Clone)")
        {
            enemyLivesLeft = 2;
        }
        else if (gameObject.name == "TaipanPrefabEnemy(Clone)")
        {
            enemyLivesLeft = 2;
        }
    
    }

    void Update()
    {
        

        if (enemyLivesLeft < 1 && gameObject != null)
        {
            Instantiate(explosionParticle,transform.position,explosionParticle.transform.rotation);
            ScoreCounter.score++;
            
        }
        if ((enemyLivesLeft < 1 && gameObject != null) || transform.position.z < -5f)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroyed()
    {
        //do nothing
    }

}
