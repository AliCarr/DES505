﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private const float Amount = 1.0f;
    [Range(0.1f, 3.0f)]
    public float speed;
    public TemperatureScript temperature;
    public SPScripts sciencePoints;
    private Transform[] waypoints;
    private int waypointIndex = 0;

    public int health;
    public int damage;
    public int value;


    public void SetWaypoints(Transform[] newWayPoints)
    {
        waypoints = newWayPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if(waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].position)
                waypointIndex++;
        }
        else
        {
            temperature.IncreaseTemperature(Amount);
            Destroy(this.gameObject);
        }

        if(health <= 0)
        {
            temperature.DecreaseTemperature(Amount);
            sciencePoints.IncreaseSciencePoints(20);
            Destroy(this.gameObject);
        }
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    int DoDamage()
    {
        return damage;
    }

}
