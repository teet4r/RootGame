using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game2ScoreText : MonoBehaviour
{
    Text scoreText;
    private void OnEnable()
    {
        scoreText = GetComponent<Text>();
        if (ScoreManager.instance.Game2ScoreMax <= 0f)
        {
            scoreText.text = "기록 없음";
        }
        else
        {
            scoreText.text = $"최고 기록 : {ScoreManager.instance.Game2ScoreMax}점";
        }
    }
}