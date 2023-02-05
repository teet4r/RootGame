using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWindowButtons : MonoBehaviour
{
    public void SelectMainMenuButton()
    {
        SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
        LoadingSceneManager.instance.LoadScene(0);
    }

    public void SelectRetryGameButton()
    {
        SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
        LoadingSceneManager.instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}