using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] SpriteRenderer chickenSprite;
    [SerializeField] bool isRight;
    [SerializeField] float scaleAddNum;
    [SerializeField] float yPositionGap;
    [SerializeField] float moveTime;
    [SerializeField] float scaleTime;
    int rand;
    Transform tr;

    public bool IsRight { get { return isRight; } }

    private void Start()
    {
        tr = GetComponent<Transform>();
        rand = Random.Range(0, 2);
        chickenSprite = GetComponent<SpriteRenderer>();
        isRight = (rand == 0) ? true : false; // true - 후라이드 false - 양념
        InitChicken();
    }

    void InitChicken()
    {
        chickenSprite.sprite = ChickenManager.instance.ChickenSprites[rand];
    }

    public void MoveChicken(int _sortingOrder)
    {
        if (_sortingOrder > 6)
        {
            Destroy(this.gameObject);
        }
        chickenSprite.sortingOrder = _sortingOrder + 2;
        StartCoroutine(ScaleUp(_sortingOrder));
        StartCoroutine(Moving());
    }

    IEnumerator ScaleUp(int _sortingOrder)
    {
        float scaletmp = 0f;
        float scaleNum = 1f / scaleTime * scaleAddNum;
        float scale = 1f + scaleAddNum * (_sortingOrder + 1);
        while (true)
        {
            if (tr.localScale.x + scaleNum * Time.deltaTime >= scale)
            {
                tr.localScale = new Vector3(scale, scale, scale);
                yield break;
            }
            scaletmp += scaleNum * Time.deltaTime;
            tr.localScale += new Vector3(scaleNum * Time.deltaTime, scaleNum * Time.deltaTime, scaleNum * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator Moving()
    {
        float yPos = 0f;
        float moveGap = 1f / moveTime * yPositionGap;
        while (true)
        {
            if (yPos - moveGap * Time.deltaTime <= -1f * yPositionGap)
            {
                tr.Translate(new Vector2(0f, (-1f * yPositionGap - yPos)));
                yield break;
            }
            yPos -= moveGap * Time.deltaTime;
            tr.Translate(new Vector2(0f, -1f * moveGap * Time.deltaTime));
            yield return null;
        }
    }
}