using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

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
    [SerializeField] Card firstCard = null;
    [SerializeField] Card secondCard = null;
    [SerializeField] int maxStage;

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
                if (stage > maxStage)
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
            yield return null;
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
        CardGameTimeBar.instance.StopTimeBar();
        yield return new WaitForSeconds(1f);
        ScoreManager.instance.SetGame3Score(score);
        clearWindow.SetActive(true);
    }

    public void GameOver()
    {
        gameOverWindow.SetActive(true);
    }

    public void SelectCard()
    {
        Card tmpCard = EventSystem.current.currentSelectedGameObject.GetComponent<Card>();
        if (firstCard == tmpCard) return;
        tmpCard.OpenCard();
        SoundManager.Instance.SfxAudio.Play(Sfx.CardSelect);
        if (firstCard == null)
        {
            firstCard = tmpCard;
        }
        else
        {
            secondCard = tmpCard;
            if (firstCard.Num / 2 == secondCard.Num / 2)
            {
                firstCard.CheckReverse();
                secondCard.CheckReverse();
                DestroyCard();
            }
            else
            {
                firstCard.CloseCard(0.5f);
                secondCard.CloseCard(0.5f);
            }
            firstCard = null;
            secondCard = null;
        }
    }

    void DestroyCard()
    {
        firstCard.DestroyCard(0.5f);
        secondCard.DestroyCard(0.5f);
    }
}