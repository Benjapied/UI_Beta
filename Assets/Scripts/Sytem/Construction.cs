using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{

    [SerializeField] private GameObject _canva;

    public void OnSelected()
    {
        //Si on clique sur le batiment, ça affiche son canva (eg: window de l'office sur le batiment office)
        _canva.SetActive(true);
    }

    public void OnHighlight()
    {
        //si on veut faire un effet de surbrillance
    }

}
