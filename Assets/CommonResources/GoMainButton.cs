using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainButton : MonoBehaviour
{
    public void SelectMainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}