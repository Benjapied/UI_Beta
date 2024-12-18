using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ElementShop : MonoBehaviour
{
    public event GameManager.UpdateNumber OnChangeEffectif;
    public event GameManager.UpdateNumber OnChangePrice;
    public event GameManager.UpdateText OnChangeName;
    public event GameManager.UpdateNumber OnChangeRatio;

    ShopFrame _frame;
    [SerializeField] Button _button;

    int _effectif = 0;
    float _price;
    int _ratio;

    public ShopFrame Frame {set => _frame = value; }
    public int Effectif { get => _effectif; }
    public int Ratio { get => _ratio; }

    public int Order { get => _frame.Order; }

    void Start()
    {
        _button.interactable = false;
    }


    public void Revelio()
    {
        transform.SetSiblingIndex(_frame.Order);
        _price = _frame.Price;
        _ratio = _frame.Ratio;
        OnChangePrice?.Invoke(_price);
        OnChangeRatio?.Invoke(_ratio);
        OnChangeEffectif?.Invoke(_effectif);
        OnChangeName?.Invoke(_frame.Title);
        GameManager.Instance.Business.OnChangeMoney += EnableButton;
    }

    public void AddToEffectif(int amount)
    {
        _effectif += amount;
        OnChangeEffectif?.Invoke(_effectif);

        GameManager.Instance.Business.RemoveMoney(_price * amount);

        _price += amount * 100f;
        OnChangePrice?.Invoke(_price);

        
    }

    private void EnableButton(float money)
    {
        if(money >= _price)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}
