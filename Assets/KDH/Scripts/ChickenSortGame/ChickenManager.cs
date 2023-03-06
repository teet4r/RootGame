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
    [SerializeField] GameObject gameClearWindow;
    [SerializeField] int chickenLength;
    [SerializeField] int combo = 0;
    [SerializeField] float comboScale;
    [SerializeField] Text comboText;
    [SerializeField] int baseScore;
    [SerializeField] float comboTime;
    [SerializeField] float comboFailTime;
    [SerializeField] Button chickenButtonLeft;
    [SerializeField] Button chickenButtonRight;

    public Sprite[] ChickenSprites { get { return chickenSprites; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        chickenLength = chickenGroup.childCount;
    }

    void RefreshScoreText()
    {
        scoreText.text = $"{score:#,###}";
    }

    public bool GetChickenType()
    {
        return chickenGroup.transform.GetChild(chickenLength - 1).GetComponent<Chicken>().IsRight;
    }

    public void SelectCorrectChicken()
    {
        combo++;
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
        }
        else
        {
            SoundManager.Instance.SfxAudio.Play(Sfx.ChickenButton);
            comboText.gameObject.SetActive(true);
        }
    }

    void RefreshComboText()
    {
        comboText.text = $"{combo} Combo";
    }

    public void SelectIncorrectChicken()
    {
        comboText.gameObject.SetActive(false);
        combo = 0;
        SoundManager.Instance.SfxAudio.Play(Sfx.ChickenFail);
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
        gameClearWindow.SetActive(true);
    }

    public void GameStart()
    {
        ActivateChickenButton();
        ChickenGameTimeBar.instance.StartTimeBar();
    }

    public void ActivateChickenButton()
    {
        chickenButtonLeft.interactable = true;
        chickenButtonRight.interactable = true;
    }
}