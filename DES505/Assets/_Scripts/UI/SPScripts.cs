using UnityEngine;
using UnityEngine.UI;

public class SPScripts : MonoBehaviour
{
    public Text sciencePointsText; 
    public float startingSciencePoints = 160f;
    public float currentSciencePoints = 160f; 

    // Start is called before the first frame update
    void Start()
    {
        currentSciencePoints = startingSciencePoints;
        sciencePointsText.text = "" + startingSciencePoints;
    }

    public void IncreaseSciencePoints(float amount)
    {
        currentSciencePoints += amount;
        sciencePointsText.text = "" + currentSciencePoints;
    }

    public void DecreaseSciencePoints(float amount)
    {
        currentSciencePoints -= amount;
        sciencePointsText.text = "" + currentSciencePoints;
    }
}
