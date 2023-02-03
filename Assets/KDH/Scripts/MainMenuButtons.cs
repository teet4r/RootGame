using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] RectTransform titleImageRectTransform;
    [SerializeField] float titleImageMoveSpeed;
    public void SelectGameStartButton()
    {
    }

    IEnumerator MoveUpTitleImage()
    {
        while (true)
        {
            titleImageRectTransform.anchoredPosition += new Vector2(0f, titleImageMoveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void SelectStartGame0Button()
    {

    }

    public void SelectStartGame1Button()
    {

    }

    public void SelectStartGame2Button()
    {

    }
}