using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject _shopParentCanva1;
    [SerializeField] GameObject _upgradeParentCanva1;
    [SerializeField] GameObject _shopParentCanva2;
    [SerializeField] GameObject _upgradeParentCanva2;
    ElementShop[] _elementsShop;
    ElementUpgrade[] _elementsUpgrade;

    List<int> _revealsNumber;
    GameManager manager;
    void Start()
    {
        manager = GameManager.Instance;
        _revealsNumber = new List<int>();
        manager.EtapeEvents[2] += RevealFirst;
        _elementsShop = _shopParentCanva1.GetComponentsInChildren<ElementShop>();
        _elementsUpgrade = _upgradeParentCanva1.GetComponentsInChildren<ElementUpgrade>();
    }

    public void UpdateShop()
    {
        foreach(ElementShop element in _elementsShop) {
            manager.AddUIPoints(element.Effectif * element.Ratio);
        }
    }
    
    void RevealFirst()
    {
        AddReveal(0);
    }

    public void AddReveal(int num)
    {
        _revealsNumber.Add(num);
    }

    public void Reveal()
    {
        foreach (int nb in _revealsNumber)
        {
            _elementsShop[nb].Revelio();
        }
        _revealsNumber.Clear();
    }
    public void ActivateElementShop(int num)
    {
        _elementsShop[num].gameObject.SetActive(true);
    }

    public void ActivateElementUpgrade(int num)
    {
        _elementsUpgrade[num].gameObject.SetActive(true);
    }

    public void UpdateAll()
    {
        foreach (ElementShop element in _elementsShop)
        {
            element.RemoveEvent();
        }
        foreach (ElementUpgrade element in _elementsUpgrade)
        {
            element.RemoveEvent();
        }

        _elementsShop = _shopParentCanva2.GetComponentsInChildren<ElementShop>();
        _elementsUpgrade = _upgradeParentCanva2.GetComponentsInChildren<ElementUpgrade>();
        foreach (ElementShop element in _elementsShop)
        {
            element.UpdateAll();
        }
        //foreach (ElementUpgrade element in _elementsUpgrade)
        //{
        //    _elementsUpgrade.UpdateAll();
        //}
    }
}
