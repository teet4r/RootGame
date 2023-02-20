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

    public void SelectCard()
    {
        image.color = Color.gray;
    }

    public void UnSelectCard()
    {
        image.color = Color.white;
    }

    public void CheckCard(bool _destroy)
    {
        StartCoroutine(RollingCard1(_destroy));
    }

    IEnumerator RollingCard1(bool _destroy)
    {
        if (_destroy) isReversed = true;
        playing = true;
        while (true)
        {
            if (rectTransform.localRotation.eulerAngles.y + rotateSpeed * Time.unscaledDeltaTime >= 90f)
            {
                StartCoroutine(RollingCard2(_destroy));
                yield break;
            }
            rectTransform.Rotate(new Vector3(0f, rectTransform.rotation.y + rotateSpeed * Time.unscaledDeltaTime, 0f));
            yield return Time.unscaledDeltaTime;
        }
    }

    IEnumerator RollingCard2(bool _destroy)
    {
        image.sprite = CardManager.instance.CardSprites[num];
        while (true)
        {
            if (rectTransform.localRotation.eulerAngles.y - rotateSpeed * Time.unscaledDeltaTime <= 0f)
            {
                yield return new WaitForSeconds(waitTime);
                if (_destroy)
                {
                    StartCoroutine(PlayDestroy());
                }
                else
                {
                    StartCoroutine(RollingCard3());
                }
                yield break;
            }
            rectTransform.Rotate(new Vector3(0f, rectTransform.rotation.y - rotateSpeed * Time.unscaledDeltaTime, 0f));
            yield return Time.unscaledDeltaTime;
        }
    }

    IEnumerator PlayDestroy()
    {
        rectTransform.rotation = Quaternion.Euler(Vector3.zero);
        while (true)
        {
            float tmpScale = rectTransform.localScale.x - Time.unscaledDeltaTime / destroyTime;
            if (image.color.a <= 0f)
            {
                image.color = Color.clear;
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