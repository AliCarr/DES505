using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GretaNPC : MonoBehaviour
{
    public Dialogue dialogue; //Using Dialogue Class
  

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);  // Find the Dialogue Mangaer and call the function "Start Dialogue"
    }
}
