using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject Enemy;
    public float creationRate = 1.3f;
    public int maxEnemies = 6;

    int currentEnemyCount = 0;
    float timer = 0;
    public Transform[] waypoints;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= creationRate && transform.childCount <= maxEnemies)
        {
            Instantiate(Enemy, transform).GetComponent<EnemyBehaviour>().SetWaypoints(waypoints);
            timer = 0;
        }

        currentEnemyCount = transform.childCount;
    }
}
