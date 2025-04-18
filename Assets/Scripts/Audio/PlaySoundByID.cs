using UnityEngine;

public class PlaySoundByID : MonoBehaviour
{
    [SerializeField] AudioClip[] _sounds;

    public void PlayById(int id)
    {
        if(id < _sounds.Length && id > -1)
        {
            UiSoundManager.Instance.PlaySound(_sounds[id]);
        }
    }
}
