using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameBGM : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.BgmAudio.Play(Bgm.CardGame);
    }
}