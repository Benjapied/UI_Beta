using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementShop : MonoBehaviour
{
    public event GameManager.UpdateNumber OnChangeEffectif;
    public event GameManager.UpdateNumber OnChangePrice;
    public event GameManager.UpdateText OnChangeName;
    public event GameManager.UpdateNumber OnChangeRatio;

    int _effectif = 0;
    float _price = 200f;
    string _name = "Worker";
    int _ratio = 1;
    
    public void AddToEffectif(int amount)
    {
        _effectif += amount;
        OnChangeEffectif?.Invoke(_effectif);

        _price += amount * 100f;
        OnChangePrice?.Invoke(_price);
    }
}
