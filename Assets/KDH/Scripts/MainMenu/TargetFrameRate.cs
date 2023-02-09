using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}