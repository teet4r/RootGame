using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenButton : MonoBehaviour
{
    public void SelectChickenButton(bool _isRight)
    {
        if (ChickenManager.instance.GetChickenType() == _isRight)
        {
            ChickenManager.instance.SelectCorrectChicken();
        }
        else
        {
            ChickenManager.instance.SelectIncorrectChicken();
        }
        ChickenManager.instance.MoveChicken();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectChickenButton(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectChickenButton(true);
        }
    }
}