using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterSpot
{
    public void PlaceContainer(LetterContainerParent con);
    public bool TryGetContainerInfo(out LetterContainerParent con);
    public void WordGuessed();
    public void ShowLetterValidation(Color from, Color to);
}
