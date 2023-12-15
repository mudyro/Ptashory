using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class EquipItem : MonoBehaviour
{
    public Transform icon;
    public Transform originalParentOfTheIcon;
    public Transform seedParent;
    public Transform birdParent;
    public Transform eggParent;
    public TMP_Text buttonText;
    public Button button;

    public Color equippedColor;
    public Color unequippedColor;
    ColorBlock colors;
    Scene currentScene;

    public bool isEquipped; 
    public bool doNotDeleteItem;

    void Start()
    {   
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.buildIndex == 5)
        {
            // buttonText = GetComponent<TMP_Text>();
            originalParentOfTheIcon = GameObject.Find("Content").GetComponent<Transform>();

            birdParent = GameObject.Find("BirdSlot").GetComponent<Transform>();
            seedParent = GameObject.Find("SeedSlot").GetComponent<Transform>();
            eggParent = GameObject.Find("EggSlot").GetComponent<Transform>();

            icon = gameObject.transform.parent;
            colors = button.colors;
        }

        else
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {

    }

    public void ChangeParentOfTheIcon()
    {
        originalParentOfTheIcon = GameObject.Find("Content").GetComponent<Transform>();
        birdParent = GameObject.Find("BirdSlot").GetComponent<Transform>();
        seedParent = GameObject.Find("SeedSlot").GetComponent<Transform>();
        eggParent = GameObject.Find("EggSlot").GetComponent<Transform>();

        icon = gameObject.transform.parent;
        colors = button.colors;

        if (!isEquipped)
        {
            if(icon.CompareTag("BirdItem"))
            {
                icon.SetParent(birdParent);
                buttonText.text = "UNEQUIP";     
                colors.selectedColor = equippedColor;
                icon.transform.localPosition = new Vector3(0,0,0);
                if (!doNotDeleteItem)
                {
                    SetItemPlayerPrefsStatusToEquipped();
                }
                doNotDeleteItem = false;
                isEquipped = true;
                // print(birdParent);

            }

            else if(icon.CompareTag("SeedItem"))
            {
                icon.SetParent(seedParent);
                buttonText.text = "UNEQUIP";     
                colors.selectedColor = equippedColor;
                icon.transform.localPosition = new Vector3(0,0,0);
                if (!doNotDeleteItem)
                {
                    SetItemPlayerPrefsStatusToEquipped();
                }
                doNotDeleteItem = false;
                isEquipped = true;
                // print(seedParent);

            }

            else if(icon.CompareTag("EggItem"))
            {
                icon.SetParent(eggParent);
                buttonText.text = "UNEQUIP";     
                colors.selectedColor = equippedColor;
                icon.transform.localPosition = new Vector3(0,0,0);
                if (!doNotDeleteItem)
                {
                    SetItemPlayerPrefsStatusToEquipped();
                }
                doNotDeleteItem = false;
                isEquipped = true;
                // print(eggParent);
            }
        }

        else 
        {
            icon.SetParent(originalParentOfTheIcon);
            buttonText.text = "EQUIP";
            colors.selectedColor = unequippedColor; 
            SetItemPlayerPrefsStatusToUnequipped();
            isEquipped = false;
        }

    button.colors = colors;
    }

    void SetItemPlayerPrefsStatusToEquipped()
    {
        for (int i = 0; i < 30; i++)
        {
            string PPValueName = PlayerPrefs.GetString("item" + i.ToString(),"EmptyItemSlot");
            // print ("This is the value before changing PP: " + PPValueName);

            if (gameObject.transform.parent.name == PPValueName)
            {
                if (gameObject.transform.parent.tag == "BirdItem")
                {
                    PlayerPrefs.SetString("item" + i.ToString(),"EmptyItemSlot");
                    PlayerPrefs.SetString("EquippedBird",gameObject.transform.parent.name);
                    RectSpawner.ItemsSavedDeleteItem();
                    break;
                }   
                else if (gameObject.transform.parent.tag == "SeedItem")
                {
                    PlayerPrefs.SetString("item" + i.ToString(),"EmptyItemSlot");
                    PlayerPrefs.SetString("EquippedSeed",gameObject.transform.parent.name);
                    RectSpawner.ItemsSavedDeleteItem();
                    break;
                }
                else if (gameObject.transform.parent.tag == "EggItem")
                {
                    PlayerPrefs.SetString("item" + i.ToString(),"EmptyItemSlot");
                    PlayerPrefs.SetString("EquippedEgg",gameObject.transform.parent.name);
                    RectSpawner.ItemsSavedDeleteItem();
                    break;
                }
            }
            // print ("This is the value after changing PP: " + PlayerPrefs.GetString("item"+i.ToString(),"Something went wrong"));

        }
    }
    void SetItemPlayerPrefsStatusToUnequipped()
    {
        for (int i = 0; i < 30; i++)
        {
            string secondPPValueName = PlayerPrefs.GetString("item" + i.ToString(),"EmptyItemSlot");
            if (secondPPValueName == "EmptyItemSlot")
            {
                if (gameObject.transform.parent.tag == "BirdItem")
                {   
                    PlayerPrefs.SetString("item" + i.ToString(),gameObject.transform.parent.name);
                    PlayerPrefs.SetString("EquippedBird","EmptyItemSlot");
                    RectSpawner.ItemsSavedAddItem();
                    break;
                }   

                else if (gameObject.transform.parent.tag == "SeedItem")
                {
                    PlayerPrefs.SetString("item" + i.ToString(),gameObject.transform.parent.name);
                    PlayerPrefs.SetString("EquippedSeed","EmptyItemSlot");
                    RectSpawner.ItemsSavedAddItem();
                    break;
                }

                else if (gameObject.transform.parent.tag == "EggItem")
                {
                    PlayerPrefs.SetString("item" + i.ToString(),gameObject.transform.parent.name);
                    PlayerPrefs.SetString("EquippedEgg","EmptyItemSlot");
                    RectSpawner.ItemsSavedAddItem();
                    break;
                }
            }
        }
    }

}
