using UnityEngine;

public class ContainerPositionValidator : MonoBehaviour
{
    [SerializeField] private LayerMask _filterMask;
    [SerializeField] private ContactFilter2D _filter;

    private Collider2D[] _results = new Collider2D[1], _characterSpots = new Collider2D[4];
    private Color _neutral = new(0f, 0f, 0f, 0f), _bad = new(1f, 0f, 0f, 125f / 255f), _good = new(0f, 1f, 0f, 125f / 255f);

    private void Awake()
    {
        _filter.SetLayerMask(_filterMask);
    }

    public void ValidateContainerPosition(LetterContainerParent con)
    {
        foreach(var ind in con.VisualIndicators)
        {
            if (Physics2D.OverlapPoint(ind.transform.position, _filter, _results) > 0)
            {
                if (_results[0].GetComponent<CharacterSpot>().IsFree)
                    ind.color = _good;
                else
                    ind.color = _bad;
            }
            else
                ind.color = _bad;
        }
    }

    public void ValidatePlacement(LetterContainerParent con)
    {
        bool validPlacement = true;

        for(int i = 0; i < con.VisualIndicators.Length; i++)
        {
            bool validPoint;

            if (Physics2D.OverlapPoint(con.VisualIndicators[i].transform.position, _filter, _results) > 0)
            {
                if (_results[0].GetComponent<CharacterSpot>().IsFree)
                {
                    _characterSpots[i] = _results[0];
                    validPoint = true;
                }
                else
                    validPoint = false;
            }
            else
                validPoint = false;

            //placement is valid only if all of the point are valid
            if (validPlacement)
                validPlacement = validPoint;
        }

        if (validPlacement)
        {
            Vector3 pos = Vector3.zero;
            for (int i = 0; i < con.VisualIndicators.Length; i++)
            {
                pos += _characterSpots[i].transform.position;
                _characterSpots[i].GetComponent<CharacterSpot>().PlaceContainer(con);
            }

            con.Place(pos / con.VisualIndicators.Length);
        }
        else
            con.Return();
    }
}
