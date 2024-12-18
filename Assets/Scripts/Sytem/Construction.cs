using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Construction : MonoBehaviour
{
    [SerializeField] private UnityEvent _event;

    public void OnSelected()
    {
        GameManager.Instance._mainCamera.LookAt = transform;
        GameManager.Instance._mainCamera.m_Lens.FieldOfView = 30;
        _event.Invoke();
    }

    public void OnHighlight()
    {
        //si on veut faire un effet de surbrillance
    }

}
