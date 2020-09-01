using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    //public string name; // NPC 

    [TextArea(3, 10)]  
    public string[] sentences;  
}
