using System.Collections;
using UnityEngine;

public class GretaNPC : MonoBehaviour
{
    public Dialogue dialogue; //Using Dialogue Class

    public void Start()
    {
        StartCoroutine(Delay());
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);  // Find the Dialogue Mangaer and call the function "Start Dialogue"
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        TriggerDialogue();
    }
}
