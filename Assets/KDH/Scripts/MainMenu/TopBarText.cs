using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopBarText : MonoBehaviour, ICustomUpdate
{
    Text topBarText;
    public string[] topBarTexts;

    private void OnEnable()
    {
        RegisterCustomUpdate();
    }

    private void Start()
    {
        topBarText = GetComponent<Text>();
    }

    public void CustomUpdate()
    {
        topBarText.text = topBarTexts[SceneManager.GetActiveScene().buildIndex];
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