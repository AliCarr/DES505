using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Round : ScriptableObject
{
    public int roundNumber;

    //How many CO2 enemies this round
    public int CO2;

    //How many SF6 enemies this round
    public int SF6;

    //How many CH4 enemies this round
    public int CH4;
}
