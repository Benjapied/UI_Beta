using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketWindow : Window
{
    public override void UpdateWindow()
    {
        base.UpdateWindow();
        GameManager.Instance.Shop.UpdateAll();
    }

}
