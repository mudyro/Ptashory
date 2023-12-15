using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class LifesLeftManager : MonoBehaviour
{
    public int playerLivesLeft;

    GameObject player;
    public GameObject lifeIcon;
    List<GameObject> allLives;

    Transform LifesLeft;

    public static bool setHightScore = false;

    void Start()
    {
        LifesLeft = GameObject.Find("LifesLeft").transform;
        playerLivesLeft = 3;
        player = GameObject.Find((PlayerPrefs.GetString("EquippedBird","01_CommonBirdIcon(Clone)").Substring(0,PlayerPrefs.GetString("EquippedBird").Length -11)));

        //check what bird is equipped and spawn player lifes depending on that
        if (PlayerPrefs.GetString("EquippedBird","01_CommonBirdIcon(Clone)") == "01_CommonBirdIcon(Clone)")
        {
            playerLivesLeft = 3;
        }
        else if(PlayerPrefs.GetString("EquippedBird","01_CommonBirdIcon(Clone)") == "01_RareBirdIcon(Clone)")
        {
            playerLivesLeft = 4;
        }
        else if (PlayerPrefs.GetString("EquippedBird","01_CommonBirdIcon(Clone)") == "01_LegBirdIcon(Clone)")
        {
            playerLivesLeft = 5;
        }
        allLives = new List<GameObject>();
        
        for (int i = 0; i < playerLivesLeft; i++)
        {   
            
            if(playerLivesLeft == 3)
            {
                GameObject heartIcon = Instantiate(lifeIcon,new Vector3(520 + i * 197, 174 ,0),Quaternion.identity,LifesLeft);
                allLives.Add(heartIcon);
            }
            else if(playerLivesLeft == 4)
            {
                GameObject heartIcon = Instantiate(lifeIcon,new Vector3(472 + i * 164, 174 ,0),Quaternion.identity,LifesLeft);
                allLives.Add(heartIcon);
            }
            else if(playerLivesLeft == 5 && i < 4)
            {
                GameObject heartIcon = Instantiate(lifeIcon,new Vector3(472 + i * 164, 250 ,0),Quaternion.identity,LifesLeft);
                allLives.Add(heartIcon);
            }
            if (i == 4)
            {
                GameObject heartIcon = Instantiate(lifeIcon,new Vector3(472, 120 ,0),Quaternion.identity,LifesLeft);
                allLives.Add(heartIcon);
            }
        }
    }   

    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find((PlayerPrefs.GetString("EquippedBird","01_CommonBirdIcon(Clone)").Substring(0,PlayerPrefs.GetString("EquippedBird").Length -11)));
        }


        if (playerLivesLeft < 1 && player != null)
        {
                setHightScore = true;
                SceneManager.LoadScene(2);

        }
    }
    void OnTriggerEnter(Collider triggerCollider)
    {
        //check if the colliding object is enemy and take one life of player.
        if (triggerCollider.gameObject.tag == "Enemy")
        {
            playerLivesLeft -= 1;
            GameObject hearthToDestroy = allLives.Last();
            Destroy(hearthToDestroy);
            allLives.RemoveAt(allLives.Count-1);
        }
    }
}
