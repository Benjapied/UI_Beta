using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loupiote : MonoBehaviour
{

    Light _light;

    void Start()
    {
        _light = GetComponent<Light>();
        _light.enabled = false;

        StartCoroutine(Pin());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Pin()
    {
        _light.enabled = false;

        yield return new WaitForSeconds(1f);

        _light.enabled = true;

        yield return new WaitForSeconds(0.1f);

        _light.enabled = false;

        yield return new WaitForSeconds(0.1f);

        _light.enabled = true;

        yield return new WaitForSeconds(0.1f);

        StartCoroutine(Pin());
    }

}
