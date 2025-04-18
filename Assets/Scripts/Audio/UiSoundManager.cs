using UnityEngine;

public class UiSoundManager : MonoBehaviour
{
    private AudioSource _source;
    private bool _soundOn = true;
    private static UiSoundManager _instance;
    public static UiSoundManager Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
        _source = GetComponent<AudioSource>();
    }
    public void SetSound(bool state)
    {
        _soundOn = state;
    }

    public void PlaySound(AudioClip clip)
    {
        if (_soundOn)
        {
            _source.clip = clip;
            _source.Play();
        }
    }
}
