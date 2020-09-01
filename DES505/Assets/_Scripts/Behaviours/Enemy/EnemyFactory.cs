﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFactory : MonoBehaviour
{
    private const int pathMax = 8;

    [SerializeField] private Transform[] waypoints = null;
    [SerializeField] private Round r = null;
    [SerializeField] private GameObject CO2EnemyObject = null;
    [SerializeField] private GameObject SF6EnemyObject = null;
    [SerializeField] private GameObject CH4EnemyObject = null;
    [SerializeField] private TemperatureScript giveTempScript = null;
    [SerializeField] private SPScripts giveSciencePoints = null;
    [SerializeField] private RoundManager roundManager = null;
    [SerializeField] private Image winImage = null;
    [SerializeField] private GameObject menuButton = null;

    private float creationRate = 2.0f;
    private int currentEnemyCount = 0;
    private float timer = 0;
    private int enemiesSpawned = 0;
    List<GameObject> spawnList = new List<GameObject>();

    private int currentRound;

    private void Start()
    {
        FillSpawnList();
    }

    public void NewRound()
    {
        FillSpawnList();
    }

    private void Update()
    {
        //Start each frame by incrementing the timer
        timer += Time.deltaTime;
        Debug.Log(spawnList.Count + " ," + currentEnemyCount);
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

        if(spawnList.Count == 0 && currentEnemyCount == 0)
        {
            Debug.Log("Working");
            currentRound++;
            enemiesSpawned = 0;
            roundManager.SetRound(currentRound);
            NewRound();
        }

        if (spawnList.Count == 0  && currentRound == 4)
        {
            Debug.Log("Working");
            winImage.gameObject.SetActive(true);
            menuButton.SetActive(true);
        }
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