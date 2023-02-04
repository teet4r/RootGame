using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffectGroup : MonoBehaviour
{
    [SerializeField] GameObject touchEffect;
    [SerializeField] int effectNum;
    [SerializeField] int effectTotalNum;
    [SerializeField] float effectTime;
    [SerializeField] float destroyTime;
    private void Start()
    {
        Destroy(this.gameObject, destroyTime);
        StartCoroutine(PlayTouchEffectGroup());
    }

    IEnumerator PlayTouchEffectGroup()
    {
        int num = 0;
        while (true)
        {
            if (num > effectTotalNum)
            {
                yield break;
            }
            num += effectNum;
            for (int i = 0; i < effectNum; i++)
            {
                Instantiate(touchEffect, transform.position, Quaternion.identity, transform);
            }
            yield return new WaitForSecondsRealtime(effectTime);
        }
    }
}