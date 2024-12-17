using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] ShopFrame[] _frames;
    [SerializeField] ElementShop _prefabElement;
    [SerializeField] GameObject _content;
    List<ElementShop> _elements;

    List<int> _revealsNumber;
    GameManager manager;
    void Start()
    {
        _revealsNumber = new List<int>();
        manager = GameManager.Instance;
        manager.EtapeEvents[2] += RevealFirst;
        _elements = new List<ElementShop>();
        for (int i = 0; i < 4; i++)
        {
            ElementShop element = Instantiate(_prefabElement, _content.transform);
            element.Frame = _frames[i];
            _elements.Add(element);
        }
    }

    public void UpdateShop()
    {
        foreach(ElementShop element in _elements) {
            manager.AddUIPoints(element.Effectif * element.Ratio);
        }
    }

    void RevealFirst()
    {
        _revealsNumber.Add(0);
        _revealsNumber.Add(1);
        _revealsNumber.Add(2);
        _revealsNumber.Add(3);
    }

    public void Reveal()
    {
        foreach(int nb in _revealsNumber)
        { 
            _elements[nb].Revelio();
        }
    }
}
