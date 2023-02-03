using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VolumeSliderHandle : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject sliderValueImage;
    [SerializeField] Text sliderValueText;

    public void RefreshValueText()
    {
        sliderValueText.text = $"{(int)(slider.value * 100)}%";
    }
}