using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Shop : MonoBehaviour
{
    [SerializeField] ShopFrame[] _frames;
    [SerializeField] ElementShop _prefabElementShop;
    [SerializeField] GameObject _contentShop;
    List<ElementShop> _elementsShop;

    [SerializeField] Upgrade[] _upgrades;
    [SerializeField] ElementUpgrade _prefabElementUpgrade;
    [SerializeField] GameObject _contentUpgrade;
    List<ElementUpgrade> _elementsUpgrade;

    List<int> _revealsNumber;
    GameManager manager;
    void Start()
    {
        _revealsNumber = new List<int>();
        manager = GameManager.Instance;
        manager.EtapeEvents[2] += RevealFirst;

        _elementsShop = new List<ElementShop>();
        for (int i = 0; i < 4; i++)
        {
            ElementShop element = Instantiate(_prefabElementShop, _contentShop.transform);
            element.Frame = _frames[i];
            _elementsShop.Add(element);
        }

        _elementsShop.Sort((a, b) => a.Order.CompareTo(b.Order));

        _elementsUpgrade = new List<ElementUpgrade>();
        for (int i = 0; i < 1; i++)
        {
            ElementUpgrade element = Instantiate(_prefabElementUpgrade, _contentUpgrade.transform);
            element.Upgrade = _upgrades[i];
            _elementsUpgrade.Add(element);
        }
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
        _revealsNumber.Sort((a, b) => _elementsShop[a].Order.CompareTo(_elementsShop[b].Order));
        foreach (int nb in _revealsNumber)
        {
            _elementsShop[nb].Revelio();
        }
        _revealsNumber.Clear();
    }

    public void Instanciate(int num)
    {
        ElementShop element = Instantiate(_prefabElementShop, _contentShop.transform);
        element.Frame = _frames[num];
        _elementsShop.Add(element);

        _elementsShop.Sort((a, b) => a.Order.CompareTo(b.Order));
    }
}
