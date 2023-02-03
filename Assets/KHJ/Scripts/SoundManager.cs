using UnityEngine;

public class SoundManager : PrefabricatedSingleton<SoundManager>
{
    public BgmAudio BgmAudio { get { return _bgmAudio; } }
    public SfxAudio SfxAudio { get { return _sfxAudio; } }

    [SerializeField] BgmAudio _bgmAudio = null;
    [SerializeField] SfxAudio _sfxAudio = null;
}

public enum Bgm
{

}

public enum Sfx
{
    EnemyKilled0, EnemyKilled1, EnemyKilled2,
    BulletHit,
    Flash,
    Gun,
    LightOff,
    LightOn,
}