using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostText : MonoBehaviour
{
    Text _costText = null;
    [SerializeField] int _costPerSecond = 10;
    [SerializeField] int _maxCost = 500;
    int _cost = 0;
    WaitForSeconds _wfs = new WaitForSeconds(1f);
    bool _isGettingCost = false;

    void Awake()
    {
        _costText = GetComponent<Text>();
    }
    void Start()
    {
        StartGetCost(_costPerSecond);
    }

    public void StartGetCost(int costPerSecond)
    {
        if (_isGettingCost)
            return;

        _isGettingCost = true;
        _costPerSecond = costPerSecond;
        StartCoroutine(_GetCost());
    }
    public void StopGetCost()
    {
        _isGettingCost = false;
    }

    IEnumerator _GetCost()
    {
        while (_isGettingCost)
        {
            _cost = Mathf.Min(_cost + _costPerSecond, _maxCost);
            _costText.text = $"{_cost} / {_maxCost}";
            yield return _wfs;
        }
    }
}
