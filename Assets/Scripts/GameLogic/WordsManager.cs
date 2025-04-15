using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WordsManager : MonoBehaviour, IWordsManager
{
    [SerializeField] private RowValidator[] _validators;
    [SerializeField] private List<string> _wordsToGuess;
    [SerializeField] private List<string> _guessedWords;
    [SerializeField] private ContainersManager _conManager;
    [SerializeField] private VictoryManager _vm;

    private readonly int maxWordsCount = 4;

    public List<string> WordsToGuess { get { return _wordsToGuess; } }

    private async Task Awake()
    {
        var info = await LevelsManager.LoadLevelInfo();

        for(int i = 0; i < maxWordsCount; i++)
        {
            _wordsToGuess.Add(info.wordsToGuess[i].ToLower());
        }

        _conManager.ReceiveContainers(info.letterContainers);
    }

    public void WordGuessed(string word)
    {
        _wordsToGuess.Remove(word);
        _guessedWords.Add(word);

        if(_wordsToGuess.Count <= 0)
        {
            _vm.OpenVictoryMenu(_guessedWords);
            LevelsManager.LevelWon();
        }
    }

    public void Validate()
    {
        foreach(var v in _validators)
        {
            v.ValidateRow();
        }
    }
}
