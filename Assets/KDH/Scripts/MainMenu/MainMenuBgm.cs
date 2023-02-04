using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBgm : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.BgmAudio.Play(Bgm.MainBGM);
    }
}