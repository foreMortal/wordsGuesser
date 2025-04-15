using UnityEngine;

public class CharacterSpot : MonoBehaviour, ICharacterSpot
{
    [SerializeField] private LetterContainerParent _placedContainer;    
    public bool IsFree { get; private set; }

    public void Awake() => IsFree = true;

    public void WordGuessed()
    {
        _placedContainer.TurnOff();
    }

    public void PlaceContainer(LetterContainerParent con)
    {
        _placedContainer = con;
        _placedContainer.ContainerGrabbed += Free;
        IsFree = false;
    }
    public bool TryGetContainerInfo(out LetterContainerParent con)
    {
        if (IsFree)
            con = null;
        else
            con = _placedContainer;

        return !IsFree;
    }
    private void Free(LetterContainerParent con)
    {
        IsFree = true;
        con.ContainerGrabbed -= Free;
        _placedContainer = null;
    }
}
