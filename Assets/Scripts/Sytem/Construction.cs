using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Construction : MonoBehaviour
{
    [SerializeField] private UnityEvent _eventSelected;
    [SerializeField] private UnityEvent _eventUnselected;

    [SerializeField] private CinemachineVirtualCamera _camera;
    public void OnSelected()
    {
        _camera.Priority = 11;

        _eventSelected.Invoke();
    }

    public void OnUnselected()
    {
        _camera.Priority = 9;
        _eventUnselected.Invoke();
    }

    public void OnHighlight()
    {
        //si on veut faire un effet de surbrillance
    }

}
