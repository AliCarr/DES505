using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public Image roundHUD;                    //HUD displaying round number
    public Sprite[] roundInfo;                //arrays of all the rounds images
    public int roundNumber = 1;               // The round number

    //Set round number and HUD accordingly
    public void SetRound(int roundInt)
    {
        if (roundInt < roundInfo.Length)
        {
            roundNumber = roundInt;
            roundHUD.sprite = roundInfo[roundInt];
        }
    }
}
