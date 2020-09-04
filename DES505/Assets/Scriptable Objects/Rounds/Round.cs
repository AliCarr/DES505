using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Round : ScriptableObject
{
    //How many CO2 enemies this round
    public int CO2;

    //How many SF6 enemies this round
    public int SF6;
 
    //How many CH4 enemies this round
    public int CH4;

    public int GetTotal()
    {
        int total = CO2 + SF6 + CH4;
        return total;
    }
}
