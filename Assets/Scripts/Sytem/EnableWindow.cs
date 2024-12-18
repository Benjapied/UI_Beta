using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWindow : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.Shop.Reveal();
    }
}
