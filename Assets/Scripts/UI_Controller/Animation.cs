using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] Vector3 _endPosition;
    public void Play()
    {
        GetComponent<RectTransform>().anchoredPosition = _endPosition;
    }
}
