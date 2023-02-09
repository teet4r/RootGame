using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlinkText : MonoBehaviour
{
    public float time;
    Text text;
    Color color;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Tap to Start";
        color = text.color;
        StartCoroutine(BlinkAlphaDownText());
    }

    IEnumerator BlinkAlphaDownText()
    {
        while (true)
        {
            if (text.color.a <= 0f)
            {
                StartCoroutine(BlinkAlphaUpText());
                yield break;
            }
            color.a -= Time.deltaTime / time;
            text.color = color;
            yield return null;
        }
    }

    IEnumerator BlinkAlphaUpText()
    {
        while(true)
        {
            if (text.color.a >= 1f)
            {
                StartCoroutine(BlinkAlphaDownText());
                yield break;
            }
            color.a += Time.deltaTime / time;
            text.color = color;
            yield return null;
        }
    }
}
