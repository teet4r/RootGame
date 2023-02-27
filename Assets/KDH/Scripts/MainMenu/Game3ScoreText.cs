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
            scoreText.text = "기록 없음";
        }
        else
        {
            scoreText.text = $"최고 기록 : {score / 60}분 {score % 60}초";
        }
    }
}