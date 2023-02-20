using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleImageChecker : MonoBehaviour
{
    public static TitleImageChecker instance;

    public bool isPlayed = false;

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
}