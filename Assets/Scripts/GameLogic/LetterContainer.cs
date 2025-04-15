using System;
using UnityEngine;
using UnityEngine.UI;

public class LetterContainer : LetterContainerParent
{
    [SerializeField] Image[] _visualIndicators;
    private bool _wasPlaced;
    public override Image[] VisualIndicators { get { return _visualIndicators; } }

    public override event Action<LetterContainerParent> ContainerGrabbed;

    public override void Place(Vector3 pos)
    {
        _wasPlaced = true;
        transform.position = pos;

        foreach (var vis in _visualIndicators)
            vis.gameObject.SetActive(false);

        _manager.RemoveContainerFromPool(this);
    }

    public override void Return()
    {
        _manager.ReturnContainerToPool(this, _wasPlaced);
        _wasPlaced = false;

        foreach (var vis in _visualIndicators)
            vis.gameObject.SetActive(false);
    }

    public override void Grab(Transform newParent)
    {
        ContainerGrabbed?.Invoke(this);
        transform.SetParent(newParent);

        foreach(var vis in _visualIndicators)
            vis.gameObject.SetActive(true);
    }

    public override void TurnOff()
    {
        gameObject.layer = 0;
    }
}
