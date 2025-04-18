using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private async UniTask Awake()
    {
        Application.targetFrameRate = 60;

        if (Application.internetReachability != NetworkReachability.NotReachable)
            await LevelsManager.LoadLevelKeys().Timeout(TimeSpan.FromSeconds(3f));
        else
            LevelsManager.WorkInOfflineMode();

       SceneManager.LoadScene(1);
    }
}
