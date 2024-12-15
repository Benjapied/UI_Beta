using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PriceUi : TextUi
{
    void OnEnable()
    {
        GameManager.Instance.Business.OnChangePriceUI += UpdateText;
    }
}
