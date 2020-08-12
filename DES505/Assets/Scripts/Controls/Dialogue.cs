using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    //public string name; // NPC 

    [TextArea(3, 10)]  // Make the sentences area Bigger
    public string[] sentences;  // Array of sentences
 
}
