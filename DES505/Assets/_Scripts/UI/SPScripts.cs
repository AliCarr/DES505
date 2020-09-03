using UnityEngine;
using UnityEngine.UI;

public class SPScripts : MonoBehaviour
{
    [SerializeField] private Text sciencePointsText;
    [SerializeField] private float startingSciencePoints = 160f;
    [SerializeField] private float currentSciencePoints = 160f; 

    // Start is called before the first frame update
    void Start()
    {
        currentSciencePoints = startingSciencePoints;
        sciencePointsText.text = startingSciencePoints.ToString();
    }

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
