using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicationWindow : Window
{

    public override void UpdateWindow()
    {
        base.UpdateWindow();
        GameManager.Instance.Communication.UpdateAll();
    }

}
