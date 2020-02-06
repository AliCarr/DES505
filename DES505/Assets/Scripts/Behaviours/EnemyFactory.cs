using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject Enemy;
    float creationRate = 1.3f;
    int maxEnemies = 6;
    int currentEnemyCount = 0;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= creationRate && transform.childCount <= maxEnemies)
        {
            Instantiate(Enemy, transform);
            timer = 0;
        }

        //currentEnemyCount = transform.childCount;
    }
}
