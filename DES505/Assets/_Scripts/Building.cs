using UnityEngine;

[System.Serializable]
public class Building : MonoBehaviour
{
    public string buildingName; 
    public float attackInterval;
    public float attackIntervalUpgraded;

    public float range; 
    public float rangeUpgraded; 
    public float damage;  
    public float damageUpgraded;  
    public float costOfBuilding;
    public float costOfUpgrade; 
    public int index;

    [TextArea(3, 10)]  
    public string descriptionOfBuilding;
}
