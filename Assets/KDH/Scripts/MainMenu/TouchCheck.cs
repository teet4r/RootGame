using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCheck : MonoBehaviour
{
    public static TouchCheck instance;
    [SerializeField] GameObject touchEffectGroup;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(touchEffectGroup, Input.mousePosition, Quaternion.identity, transform);
        }
    }
}