using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenManager : MonoBehaviour
{
    public static ChickenManager instance;

    [SerializeField] GameObject chicken;
    [SerializeField] Sprite[] chickenSprites;
    [SerializeField] Text scoreText;
    [SerializeField] int score = 0;
    [SerializeField] Transform chickenGroup;
    [SerializeField] GameObject gameOverWindow;
    [SerializeField] int chickenLength;
    [SerializeField] int combo = 0;

    public Sprite[] ChickenSprites { get { return chickenSprites; } }
    public int Score { get { return score; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        chickenLength = chickenGroup.childCount;
        RefreshScoreText();
    }

    void RefreshScoreText()
    {
        scoreText.text = $"{score}";
    }

    public bool GetChickenType()
    {
        return chickenGroup.transform.GetChild(chickenLength - 1).GetComponent<Chicken>().IsRight;
    }

    public void SelectCorrectChicken()
    {
        combo++;
        AddScore(combo);
        RefreshScoreText();
    }

    public void SelectIncorrectChicken()
    {
        combo = 0;
    }

    void AddScore(int _score)
    {
        score += _score;
    }

    public void MoveChicken()
    {
        for (int i = chickenGroup.transform.childCount - 1; i >= 0; i--)
        {
            chickenGroup.transform.GetChild(i).GetComponent<Chicken>().MoveChicken(i);
        }
        GameObject tmpObject = Instantiate(chicken, chickenGroup.position, Quaternion.identity, chickenGroup);
        tmpObject.transform.SetAsFirstSibling();
    }

    public void GameOver()
    {
        ScoreManager.instance.SetGame2Score(score);
        gameOverWindow.SetActive(true);
    }

    public void GameStart()
    {
        ChickenGameTimeBar.instance.StartTimeBar();
    }
}