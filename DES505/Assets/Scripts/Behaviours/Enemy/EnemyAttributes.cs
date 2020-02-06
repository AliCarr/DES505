using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    int health;
    int speed;

    //The amount of damage the enemy does if it reaches the end goal
    int damage;

    //the amount of science points upon defeating it
    int value;

    /// <summary>
    /// Sets the attributes of health, speed, damage, and value
    /// </summary>
    /// <param name="h">Health</param>
    /// <param name="s">Speed</param>
    /// <param name="d">Damage</param>
    /// <param name="v">Value</param>
    void initialise(int h, int s, int d, int v)
    {
        health = h;
        speed = s;
        damage = d;
        value = v;
    }
    void Update()
    {

    }
}
