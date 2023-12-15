using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGameItemSetter : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetString("EquippedBird","") == "" || PlayerPrefs.GetString("EquippedBird","") == "EmptyItemSlot") 
        {
            PlayerPrefs.SetString("EquippedBird","01_CommonBirdIcon(Clone)");
        }
        
        if (PlayerPrefs.GetString("EquippedEgg","") == "" || PlayerPrefs.GetString("EquippedEgg","") == "EmptyItemSlot") 
        {
            PlayerPrefs.SetString("EquippedEgg","03_CommonEggIcon(Clone)");
        }
        
        if (PlayerPrefs.GetString("EquippedSeed","") == "" || PlayerPrefs.GetString("EquippedSeed","") == "EmptyItemSlot") 
        {
            PlayerPrefs.SetString("EquippedSeed","02_CommonSeedIcon(Clone)");
        }

        for (int i = 0; i < 30; i++)
        {
            int itemIndex = i;
            if(PlayerPrefs.GetString("item" + itemIndex.ToString(),"") == "")
            {
                PlayerPrefs.SetString("item" + itemIndex.ToString(),"EmptyItemSlot");
            }
        }
    }
}
