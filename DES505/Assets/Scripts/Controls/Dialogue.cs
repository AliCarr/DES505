using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string name; // NPC 

    [TextArea(3, 10)]  // Make the sentences area Bigger
    public string[] sentences;  // Array of sentences
 
}
