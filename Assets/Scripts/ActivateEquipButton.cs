using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActivateEquipButton : MonoBehaviour
{
    public Transform originalParentOfIcons;
    public Transform seedParent;
    public Transform birdParent;
    public Transform eggParent;

    void Start()
    {
        originalParentOfIcons = GameObject.Find("Content").GetComponent<Transform>();
        birdParent = GameObject.Find("BirdSlot").GetComponent<Transform>();
        seedParent = GameObject.Find("SeedSlot").GetComponent<Transform>();
        eggParent = GameObject.Find("EggSlot").GetComponent<Transform>();
    }

    void Update()
    {
        
            for (int i = 0; i < originalParentOfIcons.childCount; i ++)
            {
                GameObject child = originalParentOfIcons.GetChild(i).GetChild(1).gameObject;

                if(child.transform.parent.CompareTag("BirdItem") && birdParent.childCount < 1)
                {
                    child.SetActive(true);
                }

                else if(child.transform.parent.CompareTag("SeedItem") && seedParent.childCount < 1)
                {
                    child.SetActive(true);
                }

                else if(child.transform.parent.CompareTag("EggItem") && eggParent.childCount < 1)
                {
                    child.SetActive(true);
                }
                else
                {
                    child.SetActive(false);
                }
            }
    }
      
    
}
