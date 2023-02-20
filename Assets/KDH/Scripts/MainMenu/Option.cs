using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public static Option instance;

    [SerializeField] GameObject optionButton;
    [SerializeField] GameObject optionButtonGroup;
    [SerializeField] GameObject optionWindow;
    [SerializeField] GameObject screenTopBar;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider bgmSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        ChangeSfxSliderValue();
        ChangeBgmSliderValue();
    }

    public void ActivateOptionButton(bool _tf)
    {
        optionButton.SetActive(_tf);
    }

    public void ActivateTopBar(bool _tf)
    {
        screenTopBar.SetActive(_tf);
    }

    public void CloseOptionWindow()
    {
        SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
        optionWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenOptionWindow()
    {
        SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
        CheckScene();
        optionWindow.SetActive(true);
        Time.timeScale = 0f;
    }

    void CheckScene()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            optionButtonGroup.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            optionButtonGroup.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void MoveToMainMenu()
    {
        TitleImageChecker.instance.isPlayed = true;
        SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
        CloseOptionWindow();
        LoadingSceneManager.instance.LoadScene(0);
    }

    public void ChangeSfxSliderValue()
    {
        SoundManager.Instance.SfxAudio.Volume = sfxSlider.value;
    }

    public void ChangeBgmSliderValue()
    {
        SoundManager.Instance.BgmAudio.Volume = bgmSlider.value;
    }
}