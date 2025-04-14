using UnityEngine;
using System;
using UnityEngine.UI;

public abstract class LetterContainerParent : MonoBehaviour
{
    protected IContainersManager _manager;
    public RectTransform RectTransform { get; protected set; }

    public abstract Image[] VisualIndicators { get; }
    public abstract event Action<LetterContainerParent> ContainerGrabbed;

    public void GetManager(ContainersManager m) => _manager = m;
    public abstract void Place(Vector3 pos);
    public abstract void Return();
    public abstract void Grab(Transform newParent);
}
