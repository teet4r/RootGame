using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameOverText : MonoBehaviour
{
    [SerializeField] Text scoreText;

    private void OnEnable()
    {
        int score3 = (int)(ScoreManager.instance.Game3ScoreMax);
        if (score3 == -1) scoreText.text = "기록 없음";
        else scoreText.text = $"최고 기록 : {score3 / 60}분 {score3 % 60}초\n";
    }
}