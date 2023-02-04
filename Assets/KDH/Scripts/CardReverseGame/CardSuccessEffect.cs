using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSuccessEffect : MonoBehaviour
{
    [SerializeField] GameObject circleEffect;
    [SerializeField] float effectNum;
    private void Start()
    {
        Destroy(this.gameObject, 1.0f);
        for (int i = 0; i < effectNum; i++)
        {
            Instantiate(circleEffect, GetComponent<RectTransform>().anchoredPosition, Quaternion.identity, transform);
        }
    }
}