using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteItem : MonoBehaviour
{
    string nameValueFromPlayerPrefs;
    int nameRepeatitionsCount;
    Scene currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex != 5)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(false);    
        }
        else
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);    
        }

    }

    public void DeleteInventoryItem()
    {
        if (currentScene.buildIndex == 5)
        {
            for (int i = 0; i < 30; i ++)
            {
                nameValueFromPlayerPrefs = (PlayerPrefs.GetString("item"+i.ToString(),"EmptyItemSlot")).Substring(0,PlayerPrefs.GetString("item"+i.ToString(),"EmptyItemSlot").Length - 7);

                if (nameValueFromPlayerPrefs + "(Clone)" == gameObject.name)
                {
                    PlayerPrefs.SetString("item"+i.ToString(),"EmptyItemSlot");
                    RectSpawner.ItemsSavedDeleteItem();
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
