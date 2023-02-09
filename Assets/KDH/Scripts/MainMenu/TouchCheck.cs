using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCheck : MonoBehaviour, ICustomUpdate
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

    private void OnEnable()
    {
        RegisterCustomUpdate();
    }

    public void CustomUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(touchEffectGroup, Input.mousePosition, Quaternion.identity, transform);
        }
    }

    private void OnDisable()
    {
        DeregisterCustomUpdate();
    }



    public void RegisterCustomUpdate()
    {
        CustomUpdateManager.Instance.RegisterCustomUpdate(this);
    }
    public void DeregisterCustomUpdate()
    {
        CustomUpdateManager.Instance.DeregisterCustomUpdate(this);
    }
}