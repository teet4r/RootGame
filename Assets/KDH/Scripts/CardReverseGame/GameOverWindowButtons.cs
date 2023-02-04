using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWindowButtons : MonoBehaviour
{
    public void SelectMainMenuButton()
    {
        LoadingSceneManager.instance.LoadScene(0);
    }

    public void SelectRetryGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}