using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ColdNoodleBasic : MonoBehaviour
{
    public bool isRight;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log(spriteRenderer);
    }

    public void MoveNext(int index)
    {
        this.transform.DOMove(ColdNoodleGameManager.Instance.moveTransform[index].position, 0.1f)
            .SetEase(Ease.OutFlash);         
        
        //this.transform.DOMoveX()
        //_pickedCake.DOMoveY(3f, pickingTime ).SetEase(Ease.InOutBounce);
    }

    public void MoveLeftRight(bool inputIsRight)
    {
        if (inputIsRight)
        {
            this.transform.DOMove(ColdNoodleGameManager.Instance.moveTransform[1].position, 0.5f)
                .SetEase(Ease.OutFlash);
            spriteRenderer.DOFade(0, 1);

        }else 
        {
            this.transform.DOMove(ColdNoodleGameManager.Instance.moveTransform[0].position, 0.5f)
            .SetEase(Ease.OutFlash);
            spriteRenderer.DOFade(0, 1);
        }

        //Destroy(this);
        // ColdNoodleGameManager.Instance.moveTransform[0] 왼쪽 버튼 트랜스폼
        // ColdNoodleGameManager.Instance.moveTransform[1] 오른쪽 버튼 트랜스폼
    }
}
