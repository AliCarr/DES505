using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingsFunctions : MonoBehaviour, IPointerClickHandler
{
    public bool isUpgraded = false;  // Initialise the variable which determines whether building is upgraded or not
    public GameObject upgradeButton;
    public GameObject buildingIsUpgraded;
    public GameObject cantUpgrade;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //DealDamage();
        //ReduceSpeed();
        //SpecialAttack();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            StartCoroutine(ActivateUpgradeButton());    
        }
    }

    public void DealDamage()
    {
        // FindEnemy Randomnly in range 
        // FindObjectsInRange();
        // enemy.health -= this.GetComponent<Building>().damage; do according to the attack interval

    }

    public void ReduceSpeed(float amount)
    {
        // FindEnemy Randomnly in range
        // enemy.speed -= amount; do according to the attack interval
    }

    public void FindObjectsInRange()
    {
        // bool inRange = false;
        // float range = this.GetComponent<Building>().range;
        // Gameobject enemy = FindObjectOfType<enemy>();
        // if(Mathf.distance(this.tranform.vector3 - enemy.tranform.vector3) < range)
        //{
        // inRange = true;
        //}
    }

    public void SpecialAttack()
    {
        /*
        switch(this.GetComponent<Building>().buildingName)
        {
            case "Tree" :
            //Deal extra damage to Co2
                break; 
            case "Solar Energy":
            //
                break;
            case "Wind Energy":
                break;
            case "Hydro":
                break;
            case "GTE":
                break;
            case "Biomass":
                break;
        }
        */
    }
    public void Upgrade()
    {
        if (!isUpgraded)
        {
            float costOfUprade = this.GetComponent<Building>().costOfUpgrade; // Find the variable Cost of upgrade of current building
            float currentSP = FindObjectOfType<SPScripts>().currentSciencePoints; // Find the Current Science Points
            if (currentSP >= costOfUprade)
            {
                FindObjectOfType<SPScripts>().DecreaseSciencePoints(this.GetComponent<Building>().costOfUpgrade);
                this.GetComponent<Building>().attackInterval = this.GetComponent<Building>().attackIntervalUpgraded;
                this.GetComponent<Building>().range = this.GetComponent<Building>().rangeUpgraded;
                this.GetComponent<Building>().damage = this.GetComponent<Building>().damageUpgraded;
                isUpgraded = true;
            }
            else
            {
                StartCoroutine(ActivateCantUpgradeText());
            }
        }
        else
        {
            StartCoroutine(AlreadyUpgraded());
        }
    }

    IEnumerator AlreadyUpgraded()
    {
        buildingIsUpgraded.SetActive(true);
        yield return new WaitForSeconds(2);
        buildingIsUpgraded.SetActive(false);


    }

    IEnumerator ActivateUpgradeButton()
    {
        upgradeButton.SetActive(true);
        yield return new WaitForSeconds(3);
        upgradeButton.SetActive(false);

    }

    IEnumerator ActivateCantUpgradeText()
    {
        cantUpgrade.SetActive(true);
        yield return new WaitForSeconds(2);
        cantUpgrade.SetActive(false);

    }

}
