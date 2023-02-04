using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] RectTransform titleImageRectTransform;
    [SerializeField] float titleImageMoveSpeed;
    [SerializeField] float purposeYPosition;
    [SerializeField] float titleImageMoveTime;
    [SerializeField] GameObject gameStartButtonGroup;
    [SerializeField] float buttonYPositionMoveScale;
    [SerializeField] GameObject titleTabButton;
    [SerializeField] Text titleTabButtonText;
    [SerializeField] float titleTabButtonTextAlphaTime;

    public void SelectGameStartButton()
    {
        StartCoroutine(RefreshTabButtonAlpha());
        StartCoroutine(MoveUpTitleImage());
    }

    IEnumerator RefreshTabButtonAlpha()
    {
        Color colorTmp = titleTabButtonText.color;
        while (true)
        {
            if (colorTmp.a <= 0f)
            {
                titleTabButton.SetActive(false);
                yield break;
            }
            colorTmp.a -= Time.deltaTime / titleTabButtonTextAlphaTime;
            titleTabButtonText.color = colorTmp;
            yield return null;
        }
    }

    IEnumerator MoveUpTitleImage()
    {
        while (true)
        {
            if (titleImageRectTransform.anchoredPosition.y + titleImageMoveSpeed * Time.deltaTime / titleImageMoveTime >= purposeYPosition)
            {
                titleImageRectTransform.anchoredPosition = new Vector2(0f, purposeYPosition);
                gameStartButtonGroup.SetActive(true);
                yield break;
            }
            titleImageRectTransform.anchoredPosition += new Vector2(0f, titleImageMoveSpeed * Time.deltaTime / titleImageMoveTime);
            yield return null;
        }
    }

    public void SelectStartGame0Button()
    {
        SceneManager.LoadScene(1);
    }

    public void SelectStartGame1Button()
    {
        SceneManager.LoadScene(2);
    }

    public void SelectStartGame2Button()
    {
        SceneManager.LoadScene (3);
    }
}