using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : Singleton<Console>
{
    //Class permettant d'avoir des messages qui s'affichent lorsqu'on atteint certains paliers dans une console
    //C'est stipulé à la fin du CDC en optionnel

    void PrintConsole(string str)
    {
        //On remplacera plus tard par la vraie console
        Debug.Log(str);
    }
    
}
