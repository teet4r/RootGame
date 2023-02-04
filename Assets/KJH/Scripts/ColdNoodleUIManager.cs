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
    public AudioSource comboFail;
    public float comboScaleMultiplier=1f;
    public RectTransform _rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        comboFail = GetComponent<AudioSource>();
        _rectTransform = GetComponent<RectTransform>();
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
        comboEffect.transform.DOShakeScale(0.1f, 0.5f, 5).SetEase(Ease.InOutSine);
    }
    [ContextMenu("shake2")]
    public void ShakeCombo2()
    {
        comboScaleMultiplier += 0.2f;
        comboEffect.transform.DOScale(comboScaleMultiplier, 0.5f);
        comboEffect.transform.DOShakeScale(0.15f, 3, 25).SetEase(Ease.InOutBounce);
    }

    public void MoY()
    {
        _rectTransform.DOMove(new Vector3(0,650,0),1);
    }
    public void resetComboSize()
    {
        comboScaleMultiplier = 0.5f;
        comboEffect.transform.DOScale(comboScaleMultiplier, 0.5f);
        comboFail.Play();
    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        comboEffect.SetActive(false);
        for (int i = 0; i < ColdNoodleGameManager.Instance.moveTransform.Length; i++)
        {
            ColdNoodleGameManager.Instance.moveTransform[i].gameObject.SetActive(false);    
        }
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
        comboEffect.SetActive(true);
        for (int i = 0; i < ColdNoodleGameManager.Instance.moveTransform.Length; i++)
        {
            ColdNoodleGameManager.Instance.moveTransform[i].gameObject.SetActive(true);    
        }
        Time.timeScale = 1;
    }

    public void GoMain()
    {
        SceneManager.LoadScene(0);
    }
}