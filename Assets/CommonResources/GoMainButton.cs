using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainButton : MonoBehaviour
{
    public void SelectMainMenuButton()
    {
        TitleImageChecker.instance.isPlayed = true;
        SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
        Time.timeScale = 1f;
        LoadingSceneManager.instance.LoadScene(0);
    }
}