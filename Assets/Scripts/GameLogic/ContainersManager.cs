using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ContainersManager : MonoBehaviour, IContainersManager
{
    [SerializeField] private Transform _handler;
    [SerializeField] private List<LetterContainerParent> _containers = new();

    private Vector3 startPos, endPos;
    private float _length;
    private readonly float _separator = 20f;

    private void Start()
    {
        _length = _handler.GetComponent<RectTransform>().sizeDelta.x;
        startPos = _handler.transform.localPosition;

        foreach(var c in _containers)
        {
            c.GetManager(this);
        }
        AllignContainers();
    }

    private void AllignContainers()
    {
        float xPos = 0f;

        for(int i = 0; i < _containers.Count; i++)
        {
            xPos += _separator;
            xPos += _containers[i].RectTransform.sizeDelta.x;
            _containers[i].transform.localPosition = new Vector2(xPos - _containers[i].RectTransform.sizeDelta.x / 2f, 0f);
        }
        endPos = startPos + new Vector3(xPos + _separator, 0f);
    }

    public void MoveContainers(float range)
    {
        Vector3 newPos = new (_handler.transform.localPosition.x + range, 0f);

        if (newPos.x > startPos.x)
            _handler.transform.localPosition = startPos;
        else if (newPos.x > -endPos.x)
            _handler.transform.localPosition = newPos;
    }

    public void ReturnContainerToPool(LetterContainerParent container, bool wasPlaced)
    {
        if(wasPlaced)
            _containers.Add(container);
            
        container.transform.SetParent(_handler);
        AllignContainers();
        MoveContainers(container.RectTransform.sizeDelta.x / 2f);
    }

    public void RemoveContainerFromPool(LetterContainerParent con)
    {
        _containers.Remove(con);
        AllignContainers();
        MoveContainers(con.RectTransform.sizeDelta.x / 2f);
    }
}
