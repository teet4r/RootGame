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
        if (score3 == -1) scoreText.text = "��� ����";
        else scoreText.text = $"�ְ� ��� : {score3 / 60}�� {score3 % 60}��\n";
    }
}