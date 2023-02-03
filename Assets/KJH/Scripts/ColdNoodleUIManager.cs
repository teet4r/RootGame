using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColdNoodleUIManager : SingletonMonoBehaviour<ColdNoodleUIManager>
{
    public Button stopBtn;
    public Button leftBtn;
    public Button rightBtn;
    public GameObject pauseUI;
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
        scoreText.text = "Score : " + ColdNoodleGameManager.Instance.score.ToString();
        comboText.text = ColdNoodleGameManager.Instance.combo.ToString();
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
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