using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColdNoodleUIManager : SingletonMonoBehaviour<ColdNoodleUIManager>
{
    public Button stopBtn;
    public Button leftBtn;
    public Button rightBtn;
    public Slider timeSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Min 0s, Max 60s
        timeSlider.value = ColdNoodleGameManager.Instance.timeCurrent;
    }
    
}
