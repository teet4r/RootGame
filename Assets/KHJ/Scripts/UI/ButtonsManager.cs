using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public Button[] FishButtons
    {
        get { return _fishButtons; }
    }
    public Image[] FishImages
    {
        get { return _fishImages; }
    }

    [SerializeField] Button[] _fishButtons = null;
    [SerializeField] Image[] _fishImages = null;


}
