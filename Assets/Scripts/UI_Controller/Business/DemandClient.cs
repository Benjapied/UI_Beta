using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemandClient : TextUi
{
    void OnEnable()
    {
        GameManager.Instance.Business.OnChangeDemandClient += UpdateText;
    }
}
