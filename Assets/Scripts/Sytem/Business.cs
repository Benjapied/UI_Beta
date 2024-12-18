using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class Business : MonoBehaviour
{
    public event GameManager.UpdateNumber OnChangeUIInventory;
    public event GameManager.UpdateNumber OnChangePriceUI;
    public event GameManager.UpdateNumber OnChangeDemandClient;
    public event GameManager.UpdateNumber OnChangeSalesPerSecondes;
    public event GameManager.UpdateNumber OnChangeVisibility;
    public event GameManager.UpdateNumber OnChangeMoney;

    float _money;
    float _currentUiPrice; //Prix actuel d'un UI
    float _clientDemand; //Demande du client, en pourcentage
    float _salesPerSecondes; //Nombre de ventes par secondes
    int _uiInventory; //Nombre de UI dans l'inventaire
    float _visibility; //Visibilité, permet d'augmenter la demande client, multiplicateur de vente

    float _totalClipsSold = 0f;

    //public float CurrentUiPrice { get => _currentUiPrice; set => _currentUiPrice = value; }
    //public float ClientDemand { get => _clientDemand; set => _clientDemand = value; }
    //public float SalesPerSecondes { get => _salesPerSecondes; set => _salesPerSecondes = value; }
    //public int UiInventory { get => _uiInventory; set => _uiInventory = value; }
    public float Visibility { get => _visibility; }

    private void Awake()
    {
        _currentUiPrice = 0.8f;
        _clientDemand = 0f;
        _salesPerSecondes = 0f;
        _uiInventory = 0;
        _visibility = 1;
        _money = 0f;
    }

    void Start()
    {
        OnChangePriceUI?.Invoke(_currentUiPrice);
        OnChangeUIInventory?.Invoke(_uiInventory);
        OnChangeDemandClient?.Invoke(_clientDemand);
        OnChangeSalesPerSecondes?.Invoke(_salesPerSecondes);
        OnChangeVisibility?.Invoke(_visibility);
        OnChangeMoney?.Invoke(_money);
    }

    public void IncreasePrice(float amont)
    {
        _currentUiPrice += amont;
        if (_currentUiPrice > 5f) {
            _currentUiPrice = 5f;

        }
        OnChangePriceUI?.Invoke(Mathf.Round(_currentUiPrice * 10f) / 10);
    }

    public void DecreasePrice(float amont)
    {
        _currentUiPrice -= amont;
        if (_currentUiPrice < 0.1f)
        {
            _currentUiPrice = 0.1f;
        }
        OnChangePriceUI?.Invoke(Mathf.Round(_currentUiPrice * 10f) / 10);
    }

    public void AddUIInventory(int nb)
    {
        _uiInventory += nb;
        OnChangeUIInventory?.Invoke(_uiInventory);
    }

    public void UpdateVisibility(float value)
    {
        _visibility = Mathf.Clamp(value, 0.1f, 10f);
        OnChangeVisibility?.Invoke(_visibility);
    }

    public void UpdateBusiness()
    {
        int clipsSoldPerSecond = Mathf.FloorToInt((float)(_clientDemand / 100.0 * 10.0 / _currentUiPrice)); ;

        int actualClipsSold = Mathf.Min(clipsSoldPerSecond, _uiInventory);

        ChangeRevenu(actualClipsSold);
        AddUIInventory(-actualClipsSold);

        ChangeClientDemand();
    }

    public void ChangeClientDemand()
    {

        _clientDemand = 20 / Mathf.Pow(_currentUiPrice, 1.5f) * _visibility;
        
        OnChangeDemandClient?.Invoke(Mathf.Round(_clientDemand));
    }

    public void ChangeRevenu(int clipsSold)
    {
        float revenue = clipsSold * _currentUiPrice;
        _totalClipsSold += clipsSold;
        _money += revenue;
        _salesPerSecondes = Time.time > 0f ? _totalClipsSold / Time.time : 0.0f;

        OnChangeSalesPerSecondes?.Invoke(Mathf.Round(_salesPerSecondes * 100f) / 100f);
        OnChangeMoney?.Invoke(Mathf.Round(_money * 100f) / 100f);
    }

    public void RemoveMoney(float amount)
    {
        _money -= amount;
        OnChangeMoney?.Invoke(_money);
    }

}
