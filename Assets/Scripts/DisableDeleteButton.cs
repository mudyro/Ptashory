using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDeleteButton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.transform.parent != null)
        {
            if (gameObject.transform.parent.name == "Content")
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
            }
        }

    }
}
