using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField] GameObject optionButtonGroup;
    [SerializeField] GameObject optionWindow;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider bgmSlider;

    private void Start()
    {
        ChangeSfxSliderValue();
        ChangeBgmSliderValue();
    }

    public void CloseOptionWindow()
    {
        optionWindow.SetActive(false);
    }

    public void OpenOptionWindow()
    {
        CheckScene();
        optionWindow.SetActive(true);
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
        SceneManager.LoadScene(0);
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