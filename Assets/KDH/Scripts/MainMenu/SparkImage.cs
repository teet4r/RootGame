using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkImage : MonoBehaviour
{
    [SerializeField] float scaleUpSpeed;
    [SerializeField] float scaleDownSpeed;
    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (TitleImageChecker.instance.isPlayed)
        {
            rectTransform.localScale = Vector3.one;
            return;
        }
        rectTransform.localScale = new Vector3(0f, 0f, 1f);
        StartCoroutine(ScaleUp());
    }

    IEnumerator ScaleUp()
    {
        while (true)
        {
            if (rectTransform.localScale.x + scaleUpSpeed * Time.deltaTime >= 1f)
            {
                rectTransform.localScale = Vector3.one;
                yield break;
            }
            rectTransform.localScale += new Vector3(scaleUpSpeed * Time.deltaTime, scaleUpSpeed * Time.deltaTime, 0f);
            yield return null;
        }
    }
}