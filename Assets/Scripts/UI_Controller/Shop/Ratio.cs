using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Ratio : TextUi
{
    void OnEnable()
    {
        GetComponentInParent<ElementShop>().OnChangeRatio += UpdateText;
    }
}
