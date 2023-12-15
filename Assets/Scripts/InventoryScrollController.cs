using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScrollController : MonoBehaviour
{
    public Scrollbar scrollBar;
    Vector3 scrollingPosition;
    RectTransform rectTransform;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        scrollingPosition = new Vector3(0,1521.26f * scrollBar.value,0);
        rectTransform.position = scrollingPosition;
    }
}
