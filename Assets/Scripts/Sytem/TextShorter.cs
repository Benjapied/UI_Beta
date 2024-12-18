using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

static public class TMPTOOLS
{
    static public string[] letters = { "k", "M", "B", "t", "q", "Q", "s", "S"};

    static public string ShortValue(float value)
    {
        if(value < 1000)
        {
            return value.ToString();
        }

        float diviser = 1000f;

        for(int i = 0; i < letters.Length; i++)
        {
            if(value / diviser >= 1 && value / diviser < 1000)
            {
                return (Mathf.Round(value/diviser * 100f) / 100f).ToString() + letters[i];
            }
            diviser *= 1000;
        }

        return "0";
    }
}
