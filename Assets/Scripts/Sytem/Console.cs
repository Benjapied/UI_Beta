using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Console : Singleton<Console>
{
    //Class permettant d'avoir des messages qui s'affichent lorsqu'on atteint certains paliers dans une console
    //C'est stipulé à la fin du CDC en optionnel

    [SerializeField] private GameObject _prefabText;
    private GameObject _content;

    override protected void Awake()
    {
        base.Awake();
        _content = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject; 
    }

    public void PrintConsole(string str)
    {

        GameObject obj = Instantiate(_prefabText, _content.transform);
        obj.transform.SetSiblingIndex(0);
        if(obj.TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI tmp)){

            tmp.text = str;
        }
    }
    
}
