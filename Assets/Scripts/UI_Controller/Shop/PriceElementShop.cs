using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class PriceElementShop : TextUi
{
    void OnEnable()
    {
        GetComponentInParent<ElementShop>().OnChangePrice += UpdateText;
    }
}
