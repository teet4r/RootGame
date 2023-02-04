using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCheck : MonoBehaviour
{
    [SerializeField] GameObject touchEffectGroup;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(touchEffectGroup, Input.mousePosition, Quaternion.identity, transform);
        }
    }
}