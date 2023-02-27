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
    [SerializeField] Color barColor1;
    [SerializeField] Color barColor2;
    [SerializeField] Color barColor3;

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
        timeBar.fillAmount = nowTime * _maxTime;
        nowTime -= Time.deltaTime;
        if (nowTime >= 25f)
        {
            timeBar.color = barColor1;
        }
        else if (nowTime >= 10f)
        {
            timeBar.color = barColor2;
        }else
        {
            timeBar.color = barColor3;
        }
    }
}