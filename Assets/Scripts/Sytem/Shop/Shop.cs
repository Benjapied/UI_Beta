using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Shop : MonoBehaviour
{
    [SerializeField] ElementShop[] _elementsShop;
    [SerializeField] ElementUpgrade[] _elementsUpgrade;

    List<int> _revealsNumber;
    GameManager manager;
    void Start()
    {
        manager = GameManager.Instance;
        _revealsNumber = new List<int>();
        manager.EtapeEvents[2] += RevealFirst;
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
}
