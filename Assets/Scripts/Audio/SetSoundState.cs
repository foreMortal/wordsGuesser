using UnityEngine;

public class SetSoundState : MonoBehaviour
{
    public void SetState(bool state)
    {
        UiSoundManager.Instance.SetSound(state);
    }
}
