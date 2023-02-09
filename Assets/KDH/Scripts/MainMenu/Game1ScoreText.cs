using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game1ScoreText : MonoBehaviour
{
    Text scoreText;
    private void OnEnable()
    {
        scoreText = GetComponent<Text>();
        int score = (int)(ScoreManager.instance.Game1ScoreMax * 100f);
        if (ScoreManager.instance.Game1ScoreMax <= 0f)
        {
            scoreText.text = "기록 없음";
        }
        else
        {
            scoreText.text = $"최고 기록 : {score / 60}.{score % 60}초";
        }
    }
}