using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingsFunctions : MonoBehaviour, IPointerClickHandler
{
    public bool isUpgraded = false;  // Initialise the variable which determines whether building is upgraded or not
    public GameObject upgradeButton;
    public GameObject sellButton;
    public GameObject buildingIsUpgraded;
    public GameObject cantUpgrade;
    public AudioSource buildingsSoundSource;
    public AudioClip buildingAttack;
    public GameObject[] attackProjectiles;
    public Canvas canvas;

    private GameObject[] enemiesPool;   // Using object pooling to add enemies deal damage and so on
    private GameObject enemyToGetHit; // Enemy to be dealt damage 
    private List<GameObject> enemiesToGetHit;

    private GameObject[] buildingPool;

    float timer = 0;

    //Instances of variables defining attributes of each building that will be used to define functionality and upgrade 
    private string buildingName; //String for name of the building
    private float attackInterval; //Frequency of attack
    private float attackIntervalUpgraded; //Frequency of attack after upgrade
    private float costOfUpgrade;
    private float costOfbuild;
    private float range;  //Range the building can cover
    private float rangeUpgraded;  //Range the building can cover after upgrade
    private float damage;  // Damage the building can deal
    private float damageUpgraded;  // Damage the building can deal after upgrade
    private int upgradeIndex = 0;

    public SPScripts sciencePoints;

    // Start is called before the first frame update
    public void Start()
    {
        buildingName = GetComponent<Building>().buildingName;
        attackInterval = GetComponent<Building>().attackInterval;
        attackIntervalUpgraded = GetComponent<Building>().attackIntervalUpgraded;
        costOfUpgrade = GetComponent<Building>().costOfUpgrade;
        costOfbuild = GetComponent<Building>().costOfBuilding;
        range = GetComponent<Building>().range;
        rangeUpgraded = GetComponent<Building>().rangeUpgraded;
        damage = GetComponent<Building>().damage;
        damageUpgraded = GetComponent<Building>().damageUpgraded;
        //buildingsSoundSource = GetComponent<AudioSource>();
        buildingsSoundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
        


    public void Attack()
    {
         enemiesPool = GameObject.FindGameObjectsWithTag("Enemy");
         enemiesToGetHit = new List<GameObject>();
         //Find the closest.
         for (int i = 0; i < enemiesPool.Length; ++i)
         {
              if (Vector3.Distance(enemiesPool[i].transform.position, transform.position) <= range)
              {
                 enemiesToGetHit.Add(enemiesPool[i]);
              }
        }

        IfEnemyIsOutOfRange();

        if (enemiesToGetHit.Count != 0)
        {
            if (timer >= (1 / attackInterval))
            {
                buildingsSoundSource.clip = buildingAttack;
                switch (buildingName)
                {
                    case "TREE":
                        int random = Random.Range(0, (enemiesToGetHit.Count) - 1);
                        if (enemiesToGetHit[random].name == "CO2(Clone)")
                        {
                            LaunchAttack(enemiesToGetHit[random].transform);
                            enemiesToGetHit[random].GetComponent<EnemyBehaviour>().TakeDamage(Mathf.RoundToInt(damage) + 1);
                        }
                        else
                        {
                            LaunchAttack(enemiesToGetHit[random].transform);
                            enemiesToGetHit[random].GetComponent<EnemyBehaviour>().TakeDamage(Mathf.RoundToInt(damage));
                        }
                        break;
                    case "HYDRO":
                        slowAllEnemies();
                        break;
                    case "WIND ENERGY":
                        int randomW = Random.Range(0, (enemiesToGetHit.Count) - 1);
                        SpawnHydroAttack(enemiesToGetHit[randomW].transform);
                        enemiesToGetHit[randomW].GetComponent<EnemyBehaviour>().TakeDamage(Mathf.RoundToInt(damage));
                        break;
                    case "BIOMASS":
                        BiomassBuff();
                        break;
                    default:
                        hitAllEnemies();
                        break;
                }
                timer = 0;
            }
            timer += Time.deltaTime;
           
        }
    }

    private void hitAllEnemies()
    {
        for (int j = 0; j < enemiesToGetHit.Count; j++)
        {
             LaunchAttack(enemiesToGetHit[j].transform);
            enemiesToGetHit[j].GetComponent<EnemyBehaviour>().TakeDamage(Mathf.RoundToInt(damage));
        }
    }

    private void slowAllEnemies()
    {
        for (int j = 0; j < enemiesToGetHit.Count; j++)
        {
            SpawnHydroAttack(enemiesToGetHit[j].transform);
            enemiesToGetHit[j].GetComponent<EnemyBehaviour>().ReduceSpeed(0.4f);
        }
       
    }

    private void IfEnemyIsOutOfRange()
    {
        for (int i = 0; i < enemiesToGetHit.Count; i++)
        {
            if (Vector3.Distance(enemiesToGetHit[i].transform.position, transform.position) > range)
            {
                enemiesToGetHit[i].GetComponent<EnemyBehaviour>().ReinstateSpeed();
                enemiesToGetHit.RemoveAt(i);
            }
        }
    }

    // Upgrade System
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            StartCoroutine(ActivateUpgradeButton());
        }
        if (eventData.button == PointerEventData.InputButton.Middle)
        {
            StartCoroutine(ActivateSellButton());
        }
    }
    public void Upgrade()
    {
        if (!isUpgraded)
        {
            float currentSP = sciencePoints.currentSciencePoints; // Find the Current Science Points
            if (currentSP >= costOfUpgrade)
            {
                sciencePoints.DecreaseSciencePoints(costOfUpgrade);
                attackInterval = attackIntervalUpgraded;
                range = rangeUpgraded;
                damage = damageUpgraded;
                isUpgraded = true;
                upgradeIndex = 1;
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

    IEnumerator ActivateSellButton()
    {
        sellButton.SetActive(true);
        yield return new WaitForSeconds(3);
        sellButton.SetActive(false);
    }

    IEnumerator ActivateCantUpgradeText()
    {
        cantUpgrade.SetActive(true);
        yield return new WaitForSeconds(2);
        cantUpgrade.SetActive(false);
    }

    public void Sell()
    {
        sciencePoints.IncreaseSciencePoints((costOfUpgrade + costOfbuild)/2);
        GetComponent<ClickDragAndDrop>().enabled = true;
        GetComponent<ClickDragAndDrop>().mainMap.SetTile(GetComponent<ClickDragAndDrop>().mainMap.WorldToCell(gameObject.transform.position), null);
        Destroy(gameObject);
    }

    public void LaunchAttack(Transform enemyTransform)
    {
        GameObject projectile = Instantiate(attackProjectiles[upgradeIndex], transform.position, Quaternion.identity);
        projectile.transform.SetParent(canvas.transform);
        projectile.transform.localScale = new Vector3(1, 1, 1);
        projectile.GetComponent<MovingProjectiles>().enemyTransform = enemyTransform;
       
    } 

    public void SpawnHydroAttack(Transform enemyTransform)
    {
        GameObject projectile = Instantiate(attackProjectiles[upgradeIndex], enemyTransform.position, Quaternion.identity);
        projectile.transform.SetParent(canvas.transform);
        projectile.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(ActivateDestroy(projectile));
    }

    IEnumerator ActivateDestroy(GameObject projectile)
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(projectile);
    }

    public void BiomassBuff()
    {
        buildingPool = GameObject.FindGameObjectsWithTag("Building");
        for (int i = 0; i < buildingPool.Length; i++)
        {
            if (Vector3.Distance(buildingPool[i].transform.position, transform.position) <= range)
            {
                buildingPool[i].GetComponent<Building>().range += 0.1f;
                buildingPool[i].GetComponent<Building>().rangeUpgraded += 0.1f;
            }
        }
    }
}
