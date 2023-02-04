using UnityEngine;

public class SoundManager : PrefabricatedSingleton<SoundManager>
{
    public BgmAudio BgmAudio { get { return _bgmAudio; } }
    public SfxAudio SfxAudio { get { return _sfxAudio; } }

    [SerializeField] BgmAudio _bgmAudio = null;
    [SerializeField] SfxAudio _sfxAudio = null;
}