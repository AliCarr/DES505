using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    private GameObject[] enemies;
    private GameObject current;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check for objects of a certain tag. 
        if (current == null)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemey");
            //Find the closest.
            for (int c = 0; c < enemies.Length; ++c)
            {
                if(Vector3.Distance( enemies[c].transform.position, this.transform.position) < 3)
                {
                    current = enemies[c];
                    c = enemies.Length;
                }
            }
        }
        else
        {

        }
        //is it within a certain distance
        //if so do damage
        //if not check list again for closest
        //if current has now left circle, remove as current
    }
}
