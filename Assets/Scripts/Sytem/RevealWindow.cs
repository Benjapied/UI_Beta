using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealWindow : MonoBehaviour
{
    private void OnEnable()
    {
        GameObject ui = this.gameObject;
        GameManager.Instance.Shop.Reveal();
    }

}
