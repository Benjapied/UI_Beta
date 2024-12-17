using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Effectif : TextUi
{
    void OnEnable()
    {
        GetComponentInParent<ElementShop>().OnChangeEffectif += UpdateText;
    }
}
