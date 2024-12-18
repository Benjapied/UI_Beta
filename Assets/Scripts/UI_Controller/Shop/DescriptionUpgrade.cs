using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class DescriptionUpgrade : TextUi
{
    void OnEnable()
    {
        GetComponentInParent<ElementUpgrade>().OnChangeDescription += UpdateText;
    }
}
