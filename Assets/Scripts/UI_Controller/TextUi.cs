using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUi : MonoBehaviour
{
    protected TextMeshPro _textMeshPro;

    protected void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>(); 
    }

}
