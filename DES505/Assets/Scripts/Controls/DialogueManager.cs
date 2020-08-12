using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
   // public Text nameText;
    public Text dialogueText;
    public GameObject vignette;
    public Animator dialogueAnimator;

    private Queue<string> sentences; //Queue of type string

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>(); // initialise Queue
    }

  public void StartDialogue (Dialogue dialogue)
    {       
        dialogueAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        vignette.SetActive(true);
        Time.timeScale = 0;
        dialogueAnimator.SetBool("IsOpen",true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) // For delayed dialogue appearance
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.03f);
        }
    }
    void EndDialogue()
    {
        dialogueAnimator.SetBool("IsOpen", false);
        vignette.SetActive(false);
        Time.timeScale = 1;
    }
}
