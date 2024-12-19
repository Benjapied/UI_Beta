using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade/UI", order = -10)]
public class UIUpgrade : Upgrade
{
    public override void Do()
    {
        GameManager.Instance.ImproveUI();
    }
}
