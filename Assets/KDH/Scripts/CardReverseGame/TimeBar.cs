using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    public static TimeBar instance;

    [SerializeField] float maxTime;
    [SerializeField] float nowTime;
    [SerializeField] Image timeBar;
    [SerializeField] bool timeGo;
    public float MaxTime { get { return maxTime; } }
    public float NowTime { get { return nowTime; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timeGo = true;
        FillTimeBar();
    }

    private void Update()
    {
        if (timeGo)
        {
            nowTime -= Time.deltaTime;
            timeBar.fillAmount = nowTime / maxTime;
        }
    }

    public void FillTimeBar()
    {
        nowTime = maxTime;
    }

    public void StopTimeBar()
    {
        timeGo = false;
    }

    public void StartTimeBar()
    {
        timeGo = true;
    }
}