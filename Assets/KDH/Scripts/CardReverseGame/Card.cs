using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] int num;
    [SerializeField] float rotateSpeed;
    [SerializeField] float destroyRotateSpeed;
    [SerializeField] float waitTime;
    [SerializeField] float destroyTime;
    [SerializeField] bool playing;
    [SerializeField] int effectNum;
    [SerializeField] bool isReversed = false;
    [SerializeField] Image image;
    [SerializeField] RectTransform rectTransform;
    public int Num { get { return num; } }
    public bool Playing { get { return playing; } }
    public bool IsReversed { get { return isReversed; } }

    public void OpenCard()
    {
        image.raycastTarget = false;
        StartCoroutine(RollingCard1());
    }

    public void CloseCard()
    {
        StartCoroutine(RollingCard3());
    }

    public void DestroyCard(float _time)
    {
        StartCoroutine(PlayDestroy(_time));
    }

    public void CheckReverse()
    {
        isReversed = true;
    }

    IEnumerator RollingCard1()
    {
        playing = true;
        while (true)
        {
            if (rectTransform.localRotation.eulerAngles.y + rotateSpeed * Time.unscaledDeltaTime >= 90f)
            {
                StartCoroutine(RollingCard2());
                yield break;
            }
            rectTransform.Rotate(new Vector3(0f, rectTransform.rotation.y + rotateSpeed * Time.unscaledDeltaTime, 0f));
            yield return Time.unscaledDeltaTime;
        }
    }

    IEnumerator RollingCard2()
    {
        image.sprite = CardManager.instance.CardSprites[num];
        while (true)
        {
            if (rectTransform.localRotation.eulerAngles.y - rotateSpeed * Time.unscaledDeltaTime <= 0f)
            {
                yield break;
            }
            rectTransform.Rotate(new Vector3(0f, rectTransform.rotation.y - rotateSpeed * Time.unscaledDeltaTime, 0f));
            yield return Time.unscaledDeltaTime;
        }
    }

    IEnumerator PlayDestroy(float _time)
    {
        rectTransform.rotation = Quaternion.Euler(Vector3.zero);
        yield return new WaitForSeconds(_time);
        while (true)
        {
            float tmpScale = rectTransform.localScale.x - Time.unscaledDeltaTime / destroyTime;
            if (image.color.a <= 0f)
            {
                image.color = Color.clear;
                image.raycastTarget = true;
                playing = false;
                yield break;
            }
            image.color = new Color(1f, 1f, 1f, image.color.a - Time.unscaledDeltaTime / destroyTime);
            rectTransform.Rotate(new Vector3(0f, 0f, Time.unscaledDeltaTime * destroyRotateSpeed));
            rectTransform.localScale = new Vector3(tmpScale, tmpScale, tmpScale);
            yield return Time.unscaledDeltaTime;
        }
    }

    IEnumerator RollingCard3()
    {
        rectTransform.rotation = Quaternion.Euler(Vector3.zero);
        while (true)
        {
            if (rectTransform.localRotation.eulerAngles.y + rotateSpeed * Time.unscaledDeltaTime >= 90f)
            {
                StartCoroutine(RollingCard4());
                yield break;
            }
            rectTransform.Rotate(new Vector3(0f, rectTransform.rotation.y + rotateSpeed * Time.unscaledDeltaTime, 0f));
            yield return Time.unscaledDeltaTime;
        }
    }

    IEnumerator RollingCard4()
    {
        image.sprite = CardManager.instance.CardBackSprite;
        while (true)
        {
            if (rectTransform.localRotation.eulerAngles.y - rotateSpeed * Time.unscaledDeltaTime <= 0f)
            {
                rectTransform.rotation = Quaternion.Euler(Vector3.zero);
                image.raycastTarget = true;
                playing = false;
                yield break;
            }
            rectTransform.Rotate(new Vector3(0f, rectTransform.rotation.y - rotateSpeed * Time.unscaledDeltaTime, 0f));
            yield return Time.unscaledDeltaTime;
        }
    }

    public void InitCard(int _num)
    {
        num = _num;
        image.color = Color.white;
        image.sprite = CardManager.instance.CardBackSprite;
        rectTransform.rotation = Quaternion.Euler(Vector3.zero);
        rectTransform.localScale = Vector3.one;
        isReversed = false;
    }
}