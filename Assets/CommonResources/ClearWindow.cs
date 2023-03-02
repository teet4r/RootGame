using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearWindow : MonoBehaviour
{
    const string game1RedBeanText = "¿ª½Ã ±Ùº»Àº ÆÏ ºØ¾î»§ÀÌÁö!";
    const string game1CustardText = "¿ª½Ã ±Ùº»Àº ½´Å©¸² ºØ¾î»§ÀÌÁö!";

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
            string allyType = (ScoreManager.instance.IsRedBean) ? "ÆÏºØ" : "½´ºØ";
            scoreText.text = $"ÃÖ°í ±â·Ï : {allyType} / {score1 / 60}ºÐ {score1 % 60}ÃÊ\n";
        }
        else if (sceneNum == 2)
        {
            scoreText.text = $"ÃÖ°í ±â·Ï : {ScoreManager.instance.Game2ScoreMax:#.###}Á¡\n";
        }
        else if (sceneNum == 3)
        {
            int score3 = (int)(ScoreManager.instance.Game3ScoreMax);
            scoreText.text = $"ÃÖ°í ±â·Ï : {score3 / 60}ºÐ {score3 % 60}ÃÊ\n";
        }
    }
}