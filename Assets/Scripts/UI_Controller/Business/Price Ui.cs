using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PriceUi : TextUi
{
    void Update()
    {
        _textMeshPro.text = "Price of UI: " + GameManager.Instance.business.CurrentUiPrice.ToString() + " $"; 
    }
}
