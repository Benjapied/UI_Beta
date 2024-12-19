using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coeff : TextUi
{
    [SerializeField] int index;

    void OnEnable()
    {
        GameManager.Instance.Communication.OnChangeCoeff[index] += UpdateText;
    }
}
