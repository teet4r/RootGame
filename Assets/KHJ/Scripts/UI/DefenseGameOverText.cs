using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseGameOverText : MonoBehaviour
{
    [SerializeField] Text scoreText;

    private void OnEnable()
    {
        int score1 = (int)(ScoreManager.instance.Game1ScoreMax);
        if (score1 == -1) scoreText.text = "기록 없음";
        else scoreText.text = $"최고 기록 : {score1 / 60}분 {score1 % 60}초\n";
    }
}