using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade/Usine", order = -10)]
public class Usine : Upgrade
{
    [SerializeField] int _numUsine;
    [SerializeField] int _numNextUsine;
    public override void Do()
    {
        Shop shop = GameManager.Instance.Shop;
        shop.AddReveal(_numUsine - 1);
        shop.Instanciate(_numNextUsine - 1);
    }
}
