using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostText : MonoBehaviour
{
    public Text costText = null;
    public int maxCost = 600;
    public int curCost = 0;

    int costPerSecond;
    float _time;
    float _totalTime;

    void Start()
    {
        _time = Time.time;
        _totalTime = Time.time;
    }
    void Update()
    {
        if (DefenseGameManager.instance.isGameOver) return;

        _totalTime += Time.deltaTime;
        _time += Time.deltaTime;
        if (_time > 1f)
        {
            if (_totalTime > 90f)
                costPerSecond = 25;
            else if (_totalTime > 60f)
                costPerSecond = 20;
            else if (_totalTime > 30f)
                costPerSecond = 15;
            else
                costPerSecond = 10;
            UpdateCost(curCost + costPerSecond);
            _time = 0f;
        }
    }

    public void UpdateCost(int newCost)
    {
        curCost = Mathf.Clamp(newCost, 0, maxCost);
        costText.text = $"{curCost} / {maxCost}";
    }
    public void AddCost(int additionalCost)
    {
        UpdateCost(curCost + additionalCost);
    }
}
