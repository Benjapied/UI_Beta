using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSystem : Singleton<DayNightSystem>
{
    Light _sun;
    [SerializeField] float _speed = 1f;

    private float _clock;
    private bool _isDay;

    public bool IsDay { get => _isDay; set => _isDay = value; }

    public delegate void NightDayCaller();
    public event NightDayCaller OnCallDayNight;

    override protected void Awake()
    {
        base.Awake();
        _clock = 0;
        _isDay = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        _sun = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        _clock += Time.deltaTime;
        _sun.transform.Rotate(Vector3.right * _speed * Time.deltaTime);

        if (_clock > 180 / _speed)
        {
            _isDay = !_isDay;
            OnCallDayNight?.Invoke();
            _clock = 0;
        }
    }

}
