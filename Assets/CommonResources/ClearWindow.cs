using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearWindow : MonoBehaviour
{
    const string game1RedBeanText = "���� �ٺ��� �� �ؾ����!";
    const string game1CustardText = "���� �ٺ��� ��ũ�� �ؾ����!";

    [SerializeField] Text infoText;
    [SerializeField] Text scoreText;

    private void Start()
    {
        SetWindowText();
    }

    void SetWindowText()
    {
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        if (sceneNum == 1)
        {
            if (DefenseGameManager.instance.isRedBean)
            {
                infoText.text = game1RedBeanText;
            }
            else
            {
                infoText.text = game1CustardText;
            }
            int score1 = (int)(ScoreManager.instance.Game1ScoreMax);
            string allyType = (ScoreManager.instance.IsRedBean) ? "�Ϻ�" : "����";
            scoreText.text = $"�ְ� ��� : {allyType} / {score1 / 60}�� {score1 % 60}��\n";
        }
        else if (sceneNum == 2)
        {
            scoreText.text = $"�ְ� ��� : {ScoreManager.instance.Game2ScoreMax:#.###}��\n";
        }
        else if (sceneNum == 3)
        {
            int score3 = (int)(ScoreManager.instance.Game3ScoreMax);
            scoreText.text = $"�ְ� ��� : {score3 / 60}�� {score3 % 60}��\n";
        }
    }
}