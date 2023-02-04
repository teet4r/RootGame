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
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void MoveNext(int index)
    {
        this.transform.DOMove(ColdNoodleGameManager.Instance.moveTransform[index].position,0.2f).SetEase(Ease.OutBounce);
        Debug.Log($" isRight : {isRight}가 transform[{index}]로 이동");
    }
    
    public void MoveLeftRight(bool inputIsRight)
    {
        Debug.Log($"isRight : {isRight}");
        if (inputIsRight)
        {
            this.transform.DOMove(ColdNoodleGameManager.Instance.moveTransform[1].position,0.2f).SetEase(Ease.OutBounce);
            spriteRenderer.DOFade(0, 0.3f);
        }else 
        {
            this.transform.DOMove(ColdNoodleGameManager.Instance.moveTransform[0].position,0.2f).SetEase(Ease.OutBounce);
            spriteRenderer.DOFade(0, 0.3f);
        }

        //Destroy(this);
        // ColdNoodleGameManager.Instance.moveTransform[0] 왼쪽 버튼 트랜스폼
        // ColdNoodleGameManager.Instance.moveTransform[1] 오른쪽 버튼 트랜스폼
    }
}
