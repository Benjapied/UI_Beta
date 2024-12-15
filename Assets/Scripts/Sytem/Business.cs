using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Business : MonoBehaviour
{
    public delegate void UpdateNumber(float nb);
    public event UpdateNumber OnChangeUIInventory;
    public event UpdateNumber OnChangePriceUI;
    public event UpdateNumber OnChangeDemandClient;
    public event UpdateNumber OnChangeSalesPerSecondes;
    public event UpdateNumber OnChangeVisibility;

    private float _currentUiPrice; //Prix actuel d'un UI
    private float _clientDemand; //Demande du client, en pourcentage
    private float _salesPerSecondes; //Nombre de ventes par secondes
    private int _uiInventory; //Nombre de UI dans l'inventaire
    private int _visibility; //Visibilité, permet d'augmenter la demande client, multiplicateur de vente

    public float CurrentUiPrice { get => _currentUiPrice; set => _currentUiPrice = value; }
    public float ClientDemand { get => _clientDemand; set => _clientDemand = value; }
    public float SalesPerSecondes { get => _salesPerSecondes; set => _salesPerSecondes = value; }
    public int UiInventory { get => _uiInventory; set => _uiInventory = value; }
    public int Visibility { get => _visibility; set => _visibility = value; }

    private void Awake()
    {
        Debug.Log("test");
        _currentUiPrice = 0.8f;
        _clientDemand = 0f;
        _salesPerSecondes = 0f;
        _uiInventory = 0;
        _visibility = 0;
    }

    void Start()
    {
        Debug.Log(_currentUiPrice);
        OnChangePriceUI?.Invoke(_currentUiPrice);
        OnChangeUIInventory?.Invoke(_uiInventory);
        OnChangeDemandClient?.Invoke(_clientDemand);
        OnChangeSalesPerSecondes?.Invoke(_salesPerSecondes);
        OnChangeVisibility?.Invoke(_visibility);
    }

    public void IncreasePrice(float amont)
    {
        _currentUiPrice += amont;
        OnChangePriceUI?.Invoke(_currentUiPrice);
    }

    public void DecreasePrice(float amont)
    {
        _currentUiPrice -= amont;
        OnChangePriceUI?.Invoke(_currentUiPrice);
    }

    public void AddUIInventory(int nb)
    {
        _uiInventory += nb;
        OnChangeUIInventory?.Invoke(_uiInventory);
    }

}
