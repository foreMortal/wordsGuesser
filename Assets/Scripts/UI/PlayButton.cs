using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
