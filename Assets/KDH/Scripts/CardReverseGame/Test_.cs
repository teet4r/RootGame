using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ : MonoBehaviour
{
    RectTransform rectTransform;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Debug.Log(rectTransform.anchoredPosition);
    }
}