using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenGameTimeBar : MonoBehaviour
{
    public static ChickenGameTimeBar instance;

    [SerializeField] Image timeBar;
    [SerializeField] float maxTime;
    [SerializeField] float nowTime;
    [SerializeField] Text timeText;
    float _maxTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _maxTime = 1f / maxTime;
        nowTime = maxTime;
    }

    public void StartTimeBar()
    {
        StartCoroutine(PlayTimeBar());
    }

    IEnumerator PlayTimeBar()
    {
        while(true)
        {
            RefreshTimeBar();
            if (nowTime <= 0f)
            {
                nowTime = 0f;
                ChickenManager.instance.GameOver();
                yield break;
            }
            yield return null;
        }
    }

    void RefreshTimeBar()
    {
        int _nowTime = (int)(nowTime * 10f);
        timeBar.fillAmount = nowTime * _maxTime;
        timeText.text = $"{_nowTime / 10}.{_nowTime % 10}s";
        nowTime -= Time.deltaTime;
    }

    public void AddTime(float _time)
    {
        if (nowTime + _time >= maxTime)
        {
            nowTime = maxTime;
        }
        else
        {
            nowTime += _time;
        }
    }

    public void SubTime(float _time)
    {
        if (nowTime - _time <= 0f)
        {
            nowTime = 0f;
            ChickenManager.instance.GameOver();
        }
        else
        {
            nowTime -= _time;
        }
    }
}