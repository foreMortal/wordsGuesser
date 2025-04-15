using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWordsManager
{
    public List<string> WordsToGuess { get; }

    public void WordGuessed(string word);
}
