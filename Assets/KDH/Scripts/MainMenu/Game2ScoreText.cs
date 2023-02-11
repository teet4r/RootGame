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
            scoreText.text = "��� ����";
        }
        else
        {
            scoreText.text = $"�ְ� ��� : {ScoreManager.instance.Game2ScoreMax}��";
        }
    }
}