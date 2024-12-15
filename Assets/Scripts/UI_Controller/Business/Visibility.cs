using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : TextUi
{
    void OnEnable()
    {
        GameManager.Instance.Business.OnChangeVisibility += UpdateText;
    }
}
