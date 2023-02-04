using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public static ButtonsManager instance = null;

    public Button[] fishButtons = null;
    public Image[] fishImages = null;

    [Header("----- 5°³ ¹öÆ°ÀÇ ÆÏ/½´Å©¸² ¼ø¼­ -----")]
    public AllyFish[] redBeanButtonArray = null;
    public AllyFish[] custardCreamButtonArray = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
