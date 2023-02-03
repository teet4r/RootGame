using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class BaseAudio : MonoBehaviour
{
    public bool IsMute
    {
        get { return _audioSource.mute; }
        set { _audioSource.mute = value; }
    }
    public float Volume
    {
        get { return _audioSource.volume; }
        set { _audioSource.volume = value; }
    }

    protected AudioSource _audioSource = null;
    [SerializeField] protected AudioClip[] _clips = null;

    protected virtual void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}