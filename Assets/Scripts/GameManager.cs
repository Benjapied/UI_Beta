using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public delegate void Etape();
    public Etape[] Etapes = new Etape[3];

    public delegate void UIPoints(int pts);
    public event UIPoints OnChangeUIPoints;

    int _UIPoints = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddUIPoints(int points)
    {
        _UIPoints += points;
        OnChangeUIPoints?.Invoke(_UIPoints);
    }
}
