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

    protected void UpdateText(float number)
    {
        _textMeshPro.text = $"{_textBefore} {number} {_textAfter}";
    }

    protected void UpdateText(string text)
    {
        _textMeshPro.text = text;
    }

}
