using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeWindow : Window
{
    public override void UpdateWindow()
    {
        base.UpdateWindow();
        GameManager.Instance.Business.UpdateAll();
    }

}
