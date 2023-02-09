using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenGameBgm : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.BgmAudio.Play(Bgm.ChickenGame);
    }
}