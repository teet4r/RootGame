using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipText : MonoBehaviour
{
    Text tipText;
    [SerializeField] string[] tipTexts;

    private void Start()
    {
        tipText = GetComponent<Text>();
        tipText.text = tipTexts[Random.Range(0, tipTexts.Length)];
    }
}