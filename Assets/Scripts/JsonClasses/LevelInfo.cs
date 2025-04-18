using System;

[Serializable]
public class LevelInfo
{
    public string[] wordsToGuess;
    public string[] letterContainers;

    public LevelInfo() { }
    public LevelInfo(string[] wordsToGuess, string[] containers)
    {
        this.wordsToGuess = wordsToGuess;
        letterContainers = containers;
    }
}
