using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    [SerializeField] int stage;
    [SerializeField] GameObject cardGroup;
    [SerializeField] Sprite[] cardSprites;
    [SerializeField] Sprite cardBackSprite;
    [SerializeField] int score;
    [SerializeField] GameObject clearWindow;
    [SerializeField] GameObject effectCanvas;
    [SerializeField] GameObject cardCanvas;
    public Sprite[] CardSprites { get { return cardSprites; } }
    public Sprite CardBackSprite { get { return cardBackSprite; } }
    public GameObject EffectCanvas { get { return effectCanvas; } }
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
                    score = (int)(TimeBar.instance.NowTime * 100);
                    ClearGame();
                    yield break;
                }
                TimeBar.instance.FillTimeBar();
                SetStage();
            }
            goNext = true;
            for (int i = 1; i < cardGroup.GetComponentsInChildren<RectTransform>().Length; i++)
            {
                if (cardGroup.GetComponentsInChildren<RectTransform>()[i].localScale.x > 0f)
                {
                    goNext = false;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    void SetStage()
    {
        GameObject tmpObject;
        for (int i = 0; i < (stage + 1) * 4; i++)
        {
            tmpObject = cardGroup.transform.GetChild(i).gameObject;
            tmpObject.SetActive(true);
            tmpObject.GetComponent<Card>().InitCard(i);
        }
        for (int i = 0; i < (stage + 1) * 4; i++)
        {
            cardGroup.transform.GetChild(i).transform.SetSiblingIndex(Random.Range(0, (stage + 1) * 4));
        }
        stage++;
    }

    public void ClearGame()
    {
        clearWindow.SetActive(true);
    }
}