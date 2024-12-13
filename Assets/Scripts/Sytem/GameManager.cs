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

    void Update()
    {
        if (_UIPoints >= 10 && !_Etapes[0]) {
            Etapes[0]?.Invoke();
            _Etapes[0] = true;
        }
    }

    public void AddUIPoints(int points)
    {
        _UIPoints += points;
        OnChangeUIPoints?.Invoke(_UIPoints);
    }
}
