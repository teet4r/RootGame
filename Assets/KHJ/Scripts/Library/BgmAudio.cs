public class BgmAudio : BaseAudio
{
    protected override void Awake()
    {
        base.Awake();

        _audioSource.playOnAwake = false;
        _audioSource.loop = true;
    }

    public void Play(Bgm name)
    {
        _audioSource.clip = _clips[(int)name];
        _audioSource.Play();
    }
}