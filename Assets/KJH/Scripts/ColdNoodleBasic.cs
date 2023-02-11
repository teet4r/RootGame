using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ColdNoodleBasic : MonoBehaviour
{
    public bool isRight;
    public bool isMoving; // 다음 칸으로 이동하는 동안 true
    public float t = 0.5f;
    public Transform currentTarget;
    private SpriteRenderer spriteRenderer;
    public Ease easeLR;
    public Ease easeMove;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void MoveNext(int index)
    {
        this.transform.DOMove(ColdNoodleGameManager.Instance.moveTransform[index].position,0.2f).SetEase(easeMove);
    }
    
    public void MoveLeftRight(bool inputIsRight)
    {
        if (inputIsRight)
        {
            this.transform.DOMove(ColdNoodleGameManager.Instance.moveTransform[1].position,0.2f).SetEase(easeLR);
            spriteRenderer.DOFade(0, 0.3f);
        }else 
        {
            this.transform.DOMove(ColdNoodleGameManager.Instance.moveTransform[0].position,0.2f).SetEase(easeLR);
            spriteRenderer.DOFade(0, 0.3f);
        }
    }
}
