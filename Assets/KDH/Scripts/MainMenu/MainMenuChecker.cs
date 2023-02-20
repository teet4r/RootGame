using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuChecker : MonoBehaviour
{
    [SerializeField] GameObject gameStartButtonGroup;

    private void Start()
    {
        gameStartButtonGroup.SetActive(TitleImageChecker.instance.isPlayed);
    }
}