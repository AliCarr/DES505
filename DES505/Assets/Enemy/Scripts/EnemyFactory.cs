using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject Enemy;
    public const int maxEnemies = 10;
    public const int pathMax = 3;
    public Transform[] waypoints;

    private float creationRate = 1.3f;
    private int currentEnemyCount = 0;
    private float timer = 0;
    private int enemiesSpawned = 0;

    void Update()
    {
        //Start each frame by incrementing the timer
        timer += Time.deltaTime;

        if(enemiesSpawned <= maxEnemies && timer >= creationRate && currentEnemyCount <= pathMax)
        {
            Instantiate(Enemy, transform).GetComponent<EnemyBehaviour>().SetWaypoints(waypoints);
            timer = 0;
            ++enemiesSpawned;
        }

        currentEnemyCount = transform.childCount;
    }
}
