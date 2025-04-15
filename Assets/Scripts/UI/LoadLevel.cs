using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public void Load(int index)
    {
        SceneManager.LoadScene(index);
    }
}
