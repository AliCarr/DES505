using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public string buildingName; //String for name of the building
    public float attackInterval; //Frequency of attack
    public float attackIntervalUpgraded; //Frequency of attack after upgrade

    public float range;  //Range the building can cover
    public float rangeUpgraded;  //Range the building can cover after upgrade
    public float damage;  // Damage the building can deal
    public float damageUpgraded;  // Damage the building can deal after upgrade
    public float costOfBuilding; // Science points required to build the Building
    public float costOfUpgrade;  // Science points required to upgrade the Building

    [TextArea(3, 10)]  //Make the sentence area Bigger
    public string descriptionOfBuilding; // Description of the Building
}
