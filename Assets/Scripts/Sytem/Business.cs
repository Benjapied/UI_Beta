using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Business : MonoBehaviour
{

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

    private void Start()
    {
        _currentUiPrice = 0f;
        _clientDemand = 50f;
        _salesPerSecondes = 0f;
        _uiInventory = 0;
        _visibility = 0;
    }

    public void IncreasePrice()
    {
        _currentUiPrice += 0.5f;
    }

    public void DecreasePrice()
    {
        _currentUiPrice -= 0.5f;
    }


}
