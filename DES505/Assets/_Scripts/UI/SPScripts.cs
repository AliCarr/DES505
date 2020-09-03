using UnityEngine;
using UnityEngine.UI;

public class SPScripts : MonoBehaviour
{
    [SerializeField] private Text sciencePointsText = null;
    //[SerializeField] private float startingSciencePoints = 160f;
    [SerializeField] private float currentSciencePoints = 160f; 

    public void IncreaseSciencePoints(float amount)
    {
        currentSciencePoints += amount;
        sciencePointsText.text = currentSciencePoints.ToString();
    }

    public void DecreaseSciencePoints(float amount)
    {
        currentSciencePoints -= amount;
        sciencePointsText.text = currentSciencePoints.ToString();
    }

    public float GetSciencePoints()
    {
        return currentSciencePoints;
    }
}
