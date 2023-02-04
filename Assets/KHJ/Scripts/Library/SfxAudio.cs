public class SfxAudio : BaseAudio
{
    protected override void Awake()
    {
        base.Awake();

        _audioSource.playOnAwake = false;
    }

    public void Play(Sfx name)
    {
        _audioSource.PlayOneShot(_clips[(int)name]);
    }
}