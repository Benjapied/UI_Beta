using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesPerSecondes : TextUi
{
    void OnEnable()
    {
        GameManager.Instance.Business.OnChangeSalesPerSecondes += UpdateText;
    }
}
