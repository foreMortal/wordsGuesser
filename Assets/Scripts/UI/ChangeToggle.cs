using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeToggle : MonoBehaviour
{
    [SerializeField] private Sprite _on, _off;
    private Image _sprite;

    private void Awake()
    {
        _sprite = GetComponent<Image>();
    }

    public void Toggle(bool state)
    {
        if (state)
            _sprite.sprite = _on;
        else
            _sprite.sprite = _off;
 
    }
}
