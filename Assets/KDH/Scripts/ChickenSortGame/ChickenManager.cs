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
    [SerializeField] GameObject comboImage;
    [SerializeField] float comboScale;
    [SerializeField] Text comboText;
    [SerializeField] int baseScore;
    [SerializeField] float comboTime;
    [SerializeField] float comboFailTime;

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
        ChickenGameTimeBar.instance.AddTime(comboTime);
        CheckCombo();
        RefreshComboText();
        AddScore();
        RefreshScoreText();
    }

    void CheckCombo()
    {
        if (combo % 20 == 0)
        {
            SoundManager.Instance.SfxAudio.Play(Sfx.ChickenCombo);
            comboImage.transform.localScale += new Vector3(comboScale, comboScale, comboScale);
        }
        else
        {
            SoundManager.Instance.SfxAudio.Play(Sfx.ChickenButton);
        }
    }

    void RefreshComboText()
    {
        comboText.text = $"{combo} Combo!";
    }

    public void SelectIncorrectChicken()
    {
        combo = 0;
        SoundManager.Instance.SfxAudio.Play(Sfx.ChickenFail);
        ChickenGameTimeBar.instance.SubTime(comboFailTime);
        comboImage.transform.localScale = Vector3.one;
        comboImage.SetActive(false);
    }

    void AddScore()
    {
        score += baseScore + ((combo - 1) / 10) * 50;
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