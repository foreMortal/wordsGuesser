using UnityEngine;

public class CharacterSpot : MonoBehaviour
{
    [SerializeField] private LetterContainerParent _placedContainer;    
    public bool IsFree { get; private set; }

    public void Awake() => IsFree = true;

    public void PlaceContainer(LetterContainerParent con)
    {
        _placedContainer = con;
        _placedContainer.ContainerGrabbed += Free;
        IsFree = false;
    }

    private void Free(LetterContainerParent con)
    {
        IsFree = true;
        con.ContainerGrabbed -= Free;
        _placedContainer = null;
    }
}
