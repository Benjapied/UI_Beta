using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightLight : MonoBehaviour
{

    private Light _light;

    public void Start()
    {
        _light = GetComponent<Light>();
        DayNightSystem.Instance.OnCallDayNight += OnLight;
    }

    public void OnLight()
    {
        _light.enabled = !_light.isActiveAndEnabled;
    }

}
