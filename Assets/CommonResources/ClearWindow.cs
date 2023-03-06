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
            scoreText.text = $"�ְ� ��� : {score1 / 60}�� {score1 % 60}��\n";
        }
        else if (sceneNum == 2)
        {
            scoreText.text = $"�ְ� ��� : {ScoreManager.instance.Game2ScoreMax:#.###}��\n";
        }
        else if (sceneNum == 3)
        {
            int score3 = (int)(ScoreManager.instance.Game3ScoreMax);
            scoreText.text = $"�ְ� ��� : {score3 / 60}�� {score3 % 60}��\n";
        }
    }

    public void SelectRetryGameButton()
    {
        SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
        Time.timeScale = 1;
        LoadingSceneManager.instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}