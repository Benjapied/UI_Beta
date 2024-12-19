using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade/Usine", order = -10)]
public class Usine : Upgrade
{
    [SerializeField] int _numUsine;
    [SerializeField] int _numNextUsine;
    [SerializeField] int _numNextUpgrade;
    public override void Do()
    {
        Shop shop = GameManager.Instance.Shop;
        shop.AddReveal(_numUsine - 1);
        if(_numNextUsine != 0)
        {
            shop.ActivateElementShop(_numNextUsine - 1);
        }
        if (_numNextUpgrade != 0)
        {
            shop.ActivateElementUpgrade(_numNextUpgrade - 1);
        }
        
    }
}
