using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameExitButton : MonoBehaviour
{
    [SerializeField] float alphaTime;
    float alphaSpeed;
    Image image;
    private void Start()
    {
        image = GetComponent<Image>();
        if (TitleImageChecker.instance.isPlayed)
        {
            image.color = Color.white;
            return;
        }
        alphaSpeed = 1f / alphaTime;
        StartCoroutine(PlayButtonAlpha());
    }

    IEnumerator PlayButtonAlpha()
    {
        Color color = image.color;
        while (true)
        {
            if (image.color.a >= 1f) yield break;
            color.a += Time.deltaTime * alphaSpeed;
            image.color = color;
            yield return null;
        }
    }

    public void SelectGameExitButton()
    {
        SoundManager.Instance.SfxAudio.Play(Sfx.ButtonClick);
        StartCoroutine(ExitGame());
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
}