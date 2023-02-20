using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleImage : MonoBehaviour
{
    [SerializeField] float maxSize;
    [SerializeField] float biggerScaleTime;
    [SerializeField] float smallerScaleTime;
    [SerializeField] GameObject titleButton;

    private void Start()
    {
        if (!TitleImageChecker.instance.isPlayed)
        {
            transform.localScale = Vector3.zero;
            StartCoroutine(SetScaleBigger());
        }
        else
        {
            transform.localScale = Vector3.one;
            GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 400f, 0f);
        }
    }

    IEnumerator SetScaleBigger()
    {
        float tmpScale;
        while (true)
        {
            if (transform.localScale.x + Time.deltaTime / biggerScaleTime >= maxSize)
            {
                transform.localScale = new Vector3(maxSize, maxSize, maxSize);
                StartCoroutine(SetScaleSmaller());
                yield break;
            }
            tmpScale = Time.deltaTime / biggerScaleTime;
            transform.localScale += new Vector3(tmpScale, tmpScale, tmpScale);
            yield return null;
        }
    }

    IEnumerator SetScaleSmaller()
    {
        float tmpScale;
        while (true)
        {
            if (transform.localScale.x - Time.deltaTime / smallerScaleTime <= 1f)
            {
                transform.localScale = Vector3.one;
                titleButton.SetActive(true);
                yield break;
            }
            tmpScale = Time.deltaTime / smallerScaleTime;
            transform.localScale -= new Vector3(tmpScale, tmpScale, tmpScale);
            yield return null;
        }
    }
}