using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPoints : TextUi
{
    void OnEnable()
    {
        GameManager.Instance.OnChangeUIPoints += UpdateText;
    }
}
