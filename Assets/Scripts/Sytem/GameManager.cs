using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class GameManager : Singleton<GameManager>
{

    [HideInInspector] public string _name = "Mr.Propre";

    [SerializeField] private GameObject _firstCanva;
    [SerializeField] private GameObject _secondCanva;

    public CinemachineVirtualCamera _mainCamera;
    public Window CurrentWindow;

    public delegate void Etape();
    public Etape[] EtapeEvents;

    public delegate void UpgradeUI();
    public event UpgradeUI OnUpgradeUI;

    public delegate void UpdateNumber(float nb);
    public delegate void UpdateText(string text);

    public event UpdateNumber OnChangeUIPoints;

    [HideInInspector] public bool CleanUI = false;

    [SerializeField] List<int> _steps;
    [HideInInspector] public int _currentStep = 0;

    int _energy = 100;
    int _UIPoints = 0;

    float _lastUpdateTime = 0f;

    #region Modules

    [HideInInspector] public Business Business;
    [HideInInspector] public Shop Shop;
    [HideInInspector] public Communication Communication;

    #endregion

    override protected void Awake()
    {
        base.Awake();

        EtapeEvents = new Etape[_steps.Count];

        Business = GetComponent<Business>();
        Shop = GetComponent<Shop>();
        Communication = GetComponent<Communication>();
    }

    private void Start()
    {
        OnChangeUIPoints?.Invoke(_UIPoints);
    }

    void Update()
    {
        if(_currentStep < _steps.Count && _UIPoints >= _steps[_currentStep])
        {
            //Console.Instance.PrintConsole("> Bravo vous avez atteint l'étape " + (_currentStep + 1).ToString());
            EtapeEvents[_currentStep]?.Invoke();
            _currentStep++;
        }

        if (Time.time - _lastUpdateTime >= 1.0f) {
            Business.UpdateBusiness();
            Shop.UpdateShop();
            _lastUpdateTime = Time.time;
        }

    }

    public void AddUIPoints(int points)
    {
        if (_energy <= 0) {
            return;
        }

        //_energy--;
        _UIPoints += points;
        OnChangeUIPoints?.Invoke(_UIPoints);
        Business.AddUIInventory(points);
        
    }

    public void ImproveUI()
    {
        _firstCanva.SetActive(false);
        _secondCanva.SetActive(true);
        CleanUI = true;

        OnChangeUIPoints?.Invoke(_UIPoints);
        Shop.UpdateAll();
        OnUpgradeUI?.Invoke();
        ResetWindow();
    }

    public void ChangeWindow(Window window)
    {
        if (CurrentWindow != null)
        {
            CurrentWindow.Disable();
            CurrentWindow.gameObject.SetActive(false);
        }

        CurrentWindow = window;

        if (CurrentWindow != null)
        {
            CurrentWindow.gameObject.SetActive(true);
            CurrentWindow.Enable();
        }
    }

    //public void CallWindowMarket() { ChangeWindow(); }

    public void ResetWindow()
    {
        ChangeWindow(null);
        ClickOnConstruction.Instance.ResetConstrcution();
    }

}
