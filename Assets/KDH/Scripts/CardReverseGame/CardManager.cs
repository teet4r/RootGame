using System.Collections;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    [SerializeField] int stage;
    [SerializeField] GameObject cardGroup;
    [SerializeField] Sprite[] cardSprites;
    [SerializeField] Sprite cardBackSprite;
    [SerializeField] float score;
    [SerializeField] GameObject clearWindow;
    [SerializeField] GameObject gameOverWindow;
    [SerializeField] GameObject cardCanvas;
    [SerializeField] int cardNum;
    public Sprite[] CardSprites { get { return cardSprites; } }
    public Sprite CardBackSprite { get { return cardBackSprite; } }
    public GameObject CardCanvas { get { return cardCanvas; } }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        stage = 1;
        SetStage();
        StartCoroutine(StageClearCheck());
    }

    IEnumerator StageClearCheck()
    {
        bool goNext = false;
        while (true)
        {
            if (goNext)
            {
                if (stage > 3)
                {
                    score = CardGameTimeBar.instance.NowTime;
                    StartCoroutine(GameClear());
                    yield break;
                }
                yield return new WaitForSeconds(1f);
                CardGameTimeBar.instance.FillTimeBar();
                SetStage();
            }
            goNext = true;
            for (int i = 1; i < cardNum; i++)
            {
                if (!cardGroup.transform.GetChild(i).GetComponent<Card>().IsReversed) goNext = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    void SetStage()
    {
        GameObject tmpObject;
        cardNum = (stage + 1) * 4;
        for (int i = 0; i < cardNum; i++)
        {
            tmpObject = cardGroup.transform.GetChild(i).gameObject;
            tmpObject.SetActive(true);
            tmpObject.GetComponent<Card>().InitCard(i);
        }
        for (int i = 0; i < cardNum; i++)
        {
            cardGroup.transform.GetChild(i).SetSiblingIndex(Random.Range(0, cardNum));
        }
        stage++;
    }

    IEnumerator GameClear()
    {
        CardGameTimeBar.instance.StopTImeBar();
        yield return new WaitForSeconds(1f);
        ScoreManager.instance.SetGame3Score(score);
        clearWindow.SetActive(true);
    }

    public void GameOver()
    {
        gameOverWindow.SetActive(true);
    }
}