using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    [SerializeField] int stage;
    [SerializeField] GameObject cardGroup;
    [SerializeField] Sprite[] cardSprites;
    [SerializeField] Sprite cardBackSprite;
    public Sprite[] CardSprites { get { return cardSprites; } }
    public Sprite CardBackSprite { get { return cardBackSprite; } }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        stage = 1;
        SetStage();
    }

    bool CheckCardNum()
    {
        for (int i = 0; i < cardGroup.transform.childCount; i++)
        {
            if (cardGroup.transform.GetChild(i).GetComponent<Image>().color.a > 0f)
            {
                return true;
            }
        }
        return false;
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
}