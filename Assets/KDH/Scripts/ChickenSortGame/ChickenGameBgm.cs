using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenGameBgm : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.BgmAudio.Play(Bgm.ChickenGame);
    }
}