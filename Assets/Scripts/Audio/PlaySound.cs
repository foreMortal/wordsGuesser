using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    public void Play()
    {
        UiSoundManager.Instance.PlaySound(_clip);
    }
}
