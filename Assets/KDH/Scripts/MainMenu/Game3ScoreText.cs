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
        if (ScoreManager.instance.Game3ScoreMax <= 0f)
        {
            scoreText.text = "기록 없음";
        }
        else
        {
            scoreText.text = $"최고 기록 : {ScoreManager.instance.Game3ScoreMax}초";
        }
    }
}