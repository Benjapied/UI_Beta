using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : TextUi
{
    void OnEnable()
    {
        GameManager.Instance.Business.OnChangeUIInventory += UpdateText;
    }
}
