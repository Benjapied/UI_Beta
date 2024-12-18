using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : ScriptableObject
{
    public string Title;
    public float Price;
    public string Description;

    public virtual void Do() { }
}
