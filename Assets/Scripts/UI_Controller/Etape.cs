using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etape : MonoBehaviour
{

    [SerializeField] int _numberEtape;
    void Start()
    {
        GameManager.Instance.EtapeEvents[_numberEtape - 1] += Active;
    }

    void Active()
    {
        GetComponent<Animation>().Play();
    }

}
