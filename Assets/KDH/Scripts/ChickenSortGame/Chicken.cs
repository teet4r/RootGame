using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] SpriteRenderer chickenSprite;
    [SerializeField] bool isRight;
    [SerializeField] float scaleAddNum;
    [SerializeField] float yPositionGap;
    int rand;
    Transform tr;

    public bool IsRight { get { return isRight; } }

    private void Start()
    {
        tr = GetComponent<Transform>();
        rand = Random.Range(0, 2);
        chickenSprite = GetComponent<SpriteRenderer>();
        isRight = (rand == 0) ? true : false; // true - 양념치킨 false - 후라이드치킨
        InitChicken();
    }

    void InitChicken()
    {
        chickenSprite.sprite = ChickenManager.instance.ChickenSprites[rand];
    }

    public void MoveChicken(int _sortingOrder)
    {
        if (_sortingOrder > 6) Destroy(this.gameObject);
        float scaleNum = 1f + scaleAddNum * (_sortingOrder + 1);
        tr.localScale = new Vector3(scaleNum, scaleNum, scaleNum);
        tr.Translate(new Vector3(0f, -1 * yPositionGap, 0f));
        chickenSprite.sortingOrder = _sortingOrder + 2;
    }
}