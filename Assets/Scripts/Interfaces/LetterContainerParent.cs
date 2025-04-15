using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public abstract class LetterContainerParent : MonoBehaviour
{
    protected IContainersManager _manager;
    public RectTransform RectTransform { get; protected set; }
    public string Letters { get; protected set; }
    public int Index { get; protected set; }
    public abstract Image[] VisualIndicators { get; }
    public abstract event Action<LetterContainerParent> ContainerGrabbed;

    public void GetManager(ContainersManager m) => _manager = m;
    public void Initialize(string letters, int index)
    {
        Letters = letters;
        Index = index;
        RectTransform = GetComponent<RectTransform>();
        GetComponentInChildren<TMP_Text>().text = letters;
    }
    public abstract void Place(Vector3 pos);
    public abstract void Return();
    public abstract void Grab(Transform newParent);
    public abstract void TurnOff();
}
