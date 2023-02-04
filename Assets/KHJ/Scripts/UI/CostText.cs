using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostText : MonoBehaviour
{
    public Text costText = null;
    public int costPerSecond = 10;
    public int maxCost = 500;
    public int curCost = 0;

    bool _isGettingCost = false;
    WaitForSeconds _wfs = new WaitForSeconds(1f);

    void Start()
    {
        StartGetCost(costPerSecond);
    }

    public void StartGetCost(int costPerSecond)
    {
        if (_isGettingCost)
            return;

        _isGettingCost = true;
        this.costPerSecond = costPerSecond;
        StartCoroutine(_GetCost());
    }
    public void StopGetCost()
    {
        _isGettingCost = false;
    }
    public void UpdateCost(int newCost)
    {
        curCost = Mathf.Clamp(newCost, 0, maxCost);
        costText.text = $"{curCost} / {maxCost}";
    }

    IEnumerator _GetCost()
    {
        while (_isGettingCost)
        {
            yield return _wfs;
            UpdateCost(curCost + costPerSecond);
        }
    }
}
