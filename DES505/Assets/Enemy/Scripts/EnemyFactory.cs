using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public const int pathMax = 8;
    public Transform[] waypoints;
    public Round r;
    public GameObject CO2EnemyObject;
    public GameObject SF6EnemyObject;
    public GameObject CH4EnemyObject;
    public TemperatureScript giveTempScript;
    public SPScripts giveSciencePoints;
    private float creationRate = 2.0f;
    private int currentEnemyCount = 0;
    private float timer = 0;
    private int enemiesSpawned = 0;
    List<GameObject> spawnList = new List<GameObject>();


    private void Start()
    {
        FillSpawnList();
    }
    void Update()
    {
        //Start each frame by incrementing the timer
        timer += Time.deltaTime;

     

        if (enemiesSpawned + 1 <= r.GetTotal() && timer >= creationRate && currentEnemyCount <= pathMax)
        {
            Instantiate(spawnList[spawnList.Count - 1], transform).GetComponent<EnemyBehaviour>().SetWaypoints(waypoints);
            spawnList[spawnList.Count - 1].GetComponent<EnemyBehaviour>().temperature = giveTempScript;
            spawnList[spawnList.Count - 1].GetComponent<EnemyBehaviour>().sciencePoints = giveSciencePoints;
            timer = 0;
            ++enemiesSpawned;
            spawnList.RemoveAt(spawnList.Count - 1);
        }

        currentEnemyCount = transform.childCount;
    }




    void FillSpawnList()
    {
        for(int c = 0; c < r.CO2; ++c)
        {
            spawnList.Add(CO2EnemyObject);
        }

        for (int c = 0; c < r.SF6; ++c)
        {
            spawnList.Add(SF6EnemyObject);
        }

        for (int c = 0; c < r.CH4; ++c)
        {
            spawnList.Add(CH4EnemyObject);
        }

        spawnList = Shuffle(spawnList);

    }

    private List<GameObject> Shuffle(List<GameObject> input)
    {
        List<GameObject> output = new List<GameObject>();

        Random r = new Random();
        int randomIndex = 0;
        while(input.Count > 0)
        {
            randomIndex = Random.Range(0, input.Count - 1);
            output.Add(input[randomIndex]);
            input.RemoveAt(randomIndex);
        }

        return output;
    }
}
