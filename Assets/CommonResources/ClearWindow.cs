using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearWindow : MonoBehaviour
{
    [SerializeField] Text scoreText;

    private void Start()
    {
        SetWindowText();
    }

    void SetWindowText()
    {
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        if (sceneNum == 1)
        {
            int score1 = (int)(ScoreManager.instance.Game1ScoreMax);
            scoreText.text = $"최고 기록 : {score1 / 60}분 {score1 % 60}초\n";
        }
        else if (sceneNum == 2)
        {
            scoreText.text = $"최고 기록 : {ScoreManager.instance.Game2ScoreMax:#.###}점\n";
        }
        else if (sceneNum == 3)
        {
            int score3 = (int)(ScoreManager.instance.Game3ScoreMax);
            scoreText.text = $"최고 기록 : {score3 / 60}분 {score3 % 60}초\n";
        }
    }

    public void SelectRetryGameButton()
    {
        SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
        Time.timeScale = 1;
        LoadingSceneManager.instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}