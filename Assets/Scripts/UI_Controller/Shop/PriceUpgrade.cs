using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class PriceUpdate : TextUi
{
    void OnEnable()
    {
        GetComponentInParent<ElementUpgrade>().OnChangePrice += UpdateText;
    }
}
