using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public delegate void Etape();
    public Etape[] Etapes = new Etape[3];

    public delegate void UIPoints(int pts);
    public event UIPoints OnChangeUIPoints;

    int _UIPoints = 0;
    bool[] _Etapes = new bool[3] { false, false, false };
    [SerializeField] private List<int> _steps;
    private int _currentStep = 0;

    #region Modules

    [HideInInspector] public Business business;

    #endregion

    override protected void Awake()
    {
        base.Awake();
        if(_steps.Count < _Etapes.Length)
        {
            throw new System.Exception("Not enough values in steps list");
        }     
        
        business = new Business();

    }

    void Update()
    {

        if(_currentStep < _steps.Count && _UIPoints >= _steps[_currentStep])
        {
            Etapes[_currentStep]?.Invoke();
            _Etapes[_currentStep] = true;
            _currentStep++;
        }
    }

    public void AddUIPoints(int points)
    {
        _UIPoints += points;
        OnChangeUIPoints?.Invoke(_UIPoints);
    }
}
