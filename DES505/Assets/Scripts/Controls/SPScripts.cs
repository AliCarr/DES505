using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPScripts : MonoBehaviour
{
    public Text sciencePointsText; // The text indicating the SciencePoints
    public float startingSciencePoints = 160f; // The Science Points that is when the game begins

    public float currentSciencePoints = 160f;  // The Science Points during the gameplay 

    // Start is called before the first frame update
    void Start()
    {
        // Display the SP text correctly in the beginning
        currentSciencePoints = startingSciencePoints;
        sciencePointsText.text = "" + startingSciencePoints;
    }

    public void IncreaseSciencePoints(float amount)
    {
        // Increase the CurrentSP by the amount
        currentSciencePoints += amount;

        // Display the SP text accordingly
        sciencePointsText.text = "" + currentSciencePoints;
    }

    public void DecreaseSciencePoints(float amount)
    {
        // Decrease the CurrentSP by the amount
        currentSciencePoints -= amount;

        // Display the SP text accordingly
        sciencePointsText.text = "" + currentSciencePoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
