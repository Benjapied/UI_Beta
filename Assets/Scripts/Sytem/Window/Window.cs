using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{

    virtual public void Enable()
    {
        StartCoroutine(WaitForUpdate());
    }

    virtual public void Disable()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator WaitForUpdate()
    {
        yield return 0;
        UpdateWindow();
    }

    virtual public void UpdateWindow()
    {
        //Mettre l'update de chaque window 
    }

}
