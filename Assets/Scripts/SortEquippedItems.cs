using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortEquippedItems : MonoBehaviour
{
    public Transform parentTrasform;

    List<Transform> childTransforms;

    void Start()
    {
        childTransforms = new List<Transform>();
    }

    void Update()
    {
        SortEquipment();    
    }

    void SortEquipment()
    {
        
            foreach (Transform child in parentTrasform)
            {
                childTransforms.Add(child);
            }

            if (childTransforms.Count > 0)
            {
                childTransforms.Sort((a,b) => a.name.CompareTo(b.name));

                for (int i = 0; i < childTransforms.Count; i++)
                {
                    childTransforms[i].SetSiblingIndex(i);
                }
        
        }
    }
}
