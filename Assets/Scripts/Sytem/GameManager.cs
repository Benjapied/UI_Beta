using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public delegate void Etape();
    public Etape[] EtapeEvents = new Etape[3];

    public delegate void UIPoints(int pts);
    public event UIPoints OnChangeUIPoints;

    [SerializeField] List<int> _steps;
    int _UIPoints = 0;
    int _currentStep = 0;

    float _lastUpdateTime = 0f;

    #region Modules

    [HideInInspector] public Business Business;

    #endregion

    override protected void Awake()
    {
        base.Awake();

        EtapeEvents = new Etape[_steps.Count];

        Business = GetComponent<Business>();
    }

    private void Start()
    {
        OnChangeUIPoints?.Invoke(_UIPoints);
    }

    void Update()
    {
        if(_currentStep < _steps.Count && _UIPoints >= _steps[_currentStep])
        {
            EtapeEvents[_currentStep]?.Invoke();
            _currentStep++;
        }

        if (Time.time - _lastUpdateTime >= 1.0f) {
            Business.UpdateBusiness();
            _lastUpdateTime = Time.time;
        }

    }

    public void AddUIPoints(int points)
    {
        _UIPoints += points;
        OnChangeUIPoints?.Invoke(_UIPoints);
        Business.AddUIInventory(points);
    }
}
