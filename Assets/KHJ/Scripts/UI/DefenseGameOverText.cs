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
        if (score1 == -1) scoreText.text = "��� ����";
        else scoreText.text = $"�ְ� ��� : {score1 / 60}�� {score1 % 60}��\n";
    }
}