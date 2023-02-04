using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopBarText : MonoBehaviour
{
    Text topBarText;
    public string[] topBarTexts;

    private void Start()
    {
        topBarText = GetComponent<Text>();
    }

    private void Update()
    {
        topBarText.text = topBarTexts[SceneManager.GetActiveScene().buildIndex];
    }
}