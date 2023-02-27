using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game3ScoreText : MonoBehaviour
{
    Text scoreText;
    private void OnEnable()
    {
        scoreText = GetComponent<Text>();
        int score = (int)(ScoreManager.instance.Game3ScoreMax);
        if (ScoreManager.instance.Game3ScoreMax <= 0)
        {
            scoreText.text = "��� ����";
        }
        else
        {
            scoreText.text = $"�ְ� ��� : {score / 60}�� {score % 60}��";
        }
    }
}