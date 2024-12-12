using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPoints : MonoBehaviour
{
    TMP_Text _points;
    void Start()
    {
        _points = GetComponent<TMP_Text>();
        GameManager.Instance.OnChangeUIPoints += UpdatePoints;
    }

    void UpdatePoints(int pts)
    {
        _points.text = pts.ToString();
    }
}
