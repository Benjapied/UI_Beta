using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : TextUi
{
    void OnEnable()
    {
        GameManager.Instance.Business.OnChangeMoney += UpdateText;
    }
}
