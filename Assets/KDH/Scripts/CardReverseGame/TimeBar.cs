using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBar : MonoBehaviour
{
    [SerializeField] float maxTime;
    [SerializeField] float nowTime;
    public float MaxTime { get { return maxTime; } }
    public float NowTime { get { return nowTime; } }
}