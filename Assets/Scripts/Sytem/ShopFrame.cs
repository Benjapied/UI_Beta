using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopFrame", menuName = "ShopFrame", order = -10)]
public class ShopFrame : ScriptableObject
{
    public string Title;
    public int Ratio;
    public float Price;
    public int Order;
}
