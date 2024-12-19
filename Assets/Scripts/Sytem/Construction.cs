using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Construction : MonoBehaviour
{
    [SerializeField] private Window _windowCanva1;
    [SerializeField] private Window _windowCanva2;
    [SerializeField] int _indexEtape;

    Window _currentWindow;

    [SerializeField] private CinemachineVirtualCamera _camera;

    private void Start()
    {
        GameManager.Instance.EtapeEvents[_indexEtape] += InitWindow;
    }

    void InitWindow()
    {
        if (GameManager.Instance.CleanUI)
        {
            _currentWindow = _windowCanva2;
            return;
        }
        _currentWindow = _windowCanva1;
        GameManager.Instance.OnUpgradeUI += ChangeCurrentWindow;
    }

    public void OnSelected()
    {
        _camera.Priority = 11;

        GameManager.Instance.ChangeWindow(_currentWindow);
    }

    public void OnUnselected()
    {
        _camera.Priority = 9;
    }

    public void OnHighlight()
    {
        //si on veut faire un effet de surbrillance
    }

    void ChangeCurrentWindow()
    {
        _currentWindow = _windowCanva2;
    }

}
