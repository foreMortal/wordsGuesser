using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsManager : MonoBehaviour, IWordsManager
{
    [SerializeField] private RowValidator[] _validators;
    [SerializeField] private List<string> _wordsToGuess;
    [SerializeField] private List<string> _guessedWords;
    [SerializeField] private VictoryManager _vm;

    public List<string> WordsToGuess { get { return _wordsToGuess; } }

    public void WordGuessed(string word)
    {
        _wordsToGuess.Remove(word);
        _guessedWords.Add(word);

        if(_wordsToGuess.Count <= 0)
            _vm.OpenVictoryMenu(_guessedWords);
    }

    public void Validate()
    {
        foreach(var v in _validators)
        {
            v.ValidateRow();
        }
    }
}
