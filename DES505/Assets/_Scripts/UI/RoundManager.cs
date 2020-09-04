using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RoundManager
{
    [SerializeField] private Image roundHUD = null;
    [SerializeField] private Sprite[] roundInfo = null;
    [SerializeField] private int roundNumber = 1;               

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
