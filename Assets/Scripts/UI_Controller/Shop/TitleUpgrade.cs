using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUpgrade : TextUi
{
    void OnEnable()
    {
        GetComponentInParent<ElementUpgrade>().OnChangeName += UpdateText;
    }
}
