using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class ColdNoodleUIManager : SingletonMonoBehaviour<ColdNoodleUIManager>
{
    public Button stopBtn;
    public Button leftBtn;
    public Button rightBtn;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject comboEffect;
    public Image timeImage;
    public Text scoreText;
    public Text comboText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Min 0s, Max 60s
        //timeImage.value = ColdNoodleGameManager.Instance.timeCurrent;
        timeImage.fillAmount = ColdNoodleGameManager.Instance.timeCurrent / 60f;
        scoreText.text = ColdNoodleGameManager.Instance.score.ToString();
        comboText.text = ColdNoodleGameManager.Instance.combo.ToString() + " Combo!";
    }

    [ContextMenu("shake")]
    public void ShakeCombo()
    {
        comboEffect.transform.DOShakeScale(0.5f, 0.5f, 10).SetEase(Ease.InOutSine);
    }
    [ContextMenu("shake2")]
    public void ShakeCombo2()
    {
        comboEffect.transform.DOShakeScale(0.5f, 5, 25).SetEase(Ease.InOutSine);
    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void SetActiveGameOverUI()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void GoBack()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoMain()
    {
        SceneManager.LoadScene(0);
    }
}