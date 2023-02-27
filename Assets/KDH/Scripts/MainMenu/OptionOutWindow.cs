using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionOutWindow : MonoBehaviour
{
    public void SelectOptionOutWindow()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}