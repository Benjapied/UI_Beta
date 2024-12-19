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

    [SerializeField] ShopFrame _frame;
    [SerializeField] Button _button;

    int _effectif = 0;
    float _price;
    int _ratio;

    public int Effectif { get => _effectif; }
    public int Ratio { get => _ratio; }

    public int Order { get => _frame.Order; }

    void Start()
    {
        _button.interactable = false;
    }


    public void Revelio()
    {
        StartCoroutine(WaitNextFrame());
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

    IEnumerator WaitNextFrame()
    {
        yield return 0;
        _price = _frame.Price;
        _ratio = _frame.Ratio;
        TextUi[] texts = GetComponentsInChildren<TextUi>();
        texts[0].UpdateText(_frame.Title);
        texts[1].UpdateText(_ratio);
        texts[2].UpdateText(_effectif);
        texts[3].UpdateText(_price);
        GameManager.Instance.Business.OnChangeMoney += EnableButton;
    }

    public void RemoveEvent()
    {
        GameManager.Instance.Business.OnChangeMoney -= EnableButton;
    }

    public void UpdateAll()
    {
        OnChangeEffectif?.Invoke(_effectif);
        OnChangePrice?.Invoke(_price);
    }
}
