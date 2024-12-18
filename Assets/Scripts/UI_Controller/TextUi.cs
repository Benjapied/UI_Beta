using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextUi : MonoBehaviour
{
    protected TMP_Text _textMeshPro;

    [SerializeField] protected string _textBefore;
    [SerializeField] protected string _textAfter;

    void Awake()
    {
        _textMeshPro = GetComponent<TMP_Text>();
    }

    public void UpdateText(float number)
    {
        _textMeshPro.text = $"{_textBefore} {TMPTOOLS.ShortValue(number)} {_textAfter}";
    }

    public void UpdateText(string text)
    {
        _textMeshPro.text = text;
    }

}
