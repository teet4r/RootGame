using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class ColdNoodleUIManager : Singleton<ColdNoodleUIManager>, ICustomUpdate
{
    public Button leftBtn;
    public Button rightBtn;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject comboEffect;
    public Image timeImage;
    public Text scoreText;
    public Text comboText;
    public float comboScaleMultiplier=1f;
    public RectTransform _rectTransform;

    void OnEnable()
    {
        RegisterCustomUpdate();
    }
    void Start()
    {
        leftBtn.interactable = true;
        rightBtn.interactable = true;
        timeImage.fillAmount = ColdNoodleGameManager.Instance.timeCurrent / 60f;
        _rectTransform = GetComponent<RectTransform>();
    }
    public void CustomUpdate()
    {
        // Min 0s, Max 60s
        //timeImage.value = ColdNoodleGameManager.Instance.timeCurrent;
        timeImage.fillAmount = ColdNoodleGameManager.Instance.timeCurrent / 60f;
        scoreText.text = ColdNoodleGameManager.Instance.score.ToString();
        comboText.text = ColdNoodleGameManager.Instance.combo.ToString() + " Combo!";
    }
    void OnDisable()
    {
        DeregisterCustomUpdate();
    }

    [ContextMenu("shake")]
    public void ShakeCombo()
    {
        comboEffect.transform.DOShakeScale(0.1f, 0.5f, 5).SetEase(Ease.InOutSine);
    }
    [ContextMenu("shake2")]
    public void ShakeCombo2()
    {
        comboScaleMultiplier += 0.12f;
        comboEffect.transform.DOScale(comboScaleMultiplier, 0.5f);
        comboEffect.transform.DOShakeScale(0.15f, 1, 25).SetEase(Ease.InOutBounce);
    }

    public void MoY()
    {
        _rectTransform.DOMove(new Vector3(0,650,0),1);
    }
    public void resetComboSize()
    {
        comboScaleMultiplier = 0.5f;
        comboEffect.transform.DOScale(comboScaleMultiplier, 0.5f);
        SoundManager.Instance.SfxAudio.Play(Sfx.ChickenFail);
    }
    public void Pause()
    {
        SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
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
        leftBtn.interactable = false;
        rightBtn.interactable = false;
        gameOverUI.SetActive(true);
    }

    public void GoBack()
    {
        SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
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
        SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
        LoadingSceneManager.instance.LoadScene(0);
        Time.timeScale = 1;
    }

    public void LoadChick()
    {
        SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }



    public void RegisterCustomUpdate()
    {
        CustomUpdateManager.Instance.RegisterCustomUpdate(this);
    }
    public void DeregisterCustomUpdate()
    {
        CustomUpdateManager.Instance.DeregisterCustomUpdate(this);
    }
}