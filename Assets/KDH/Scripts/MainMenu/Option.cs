using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField] GameObject optionButton;
    [SerializeField] GameObject optionButtonGroup;
    [SerializeField] GameObject optionWindow;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider bgmSlider;

    private void Start()
    {
        ChangeSfxSliderValue();
        ChangeBgmSliderValue();
        StartCoroutine(ActivateOptionButton());
    }

    IEnumerator ActivateOptionButton()
    {
        while (true)
        {
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                optionButton.SetActive(false);
            }
            else
            {
                optionButton.SetActive(true);
            }
            yield return new WaitForSeconds(0.04f);
        }
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