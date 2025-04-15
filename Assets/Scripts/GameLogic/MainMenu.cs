using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private async Task Awake()
    {
        await LevelsManager.LoadLevelKeys();
    }
}
