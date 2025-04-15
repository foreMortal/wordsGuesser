using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryManager : MonoBehaviour, IVicatoryManager
{
    [SerializeField] private TMP_Text[] _words;
    public void OpenVictoryMenu(List<string> guessedWords)
    {
        gameObject.SetActive(true);

        for (int i = 0; i < guessedWords.Count; i++)
        {
            _words[i].text = guessedWords[i].ToUpper();
        }
    }
}
