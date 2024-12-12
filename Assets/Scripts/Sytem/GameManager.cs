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

    override public void Awake()
    {
        SceneManager.LoadScene("UI",LoadSceneMode.Additive);
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
