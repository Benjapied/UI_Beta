using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : TextUi
{
    void OnEnable()
    {
        GetComponentInParent<ElementShop>().OnChangeName += UpdateText;
    }
}
