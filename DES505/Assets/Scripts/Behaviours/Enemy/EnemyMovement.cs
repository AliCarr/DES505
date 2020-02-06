using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION { NORTH, SOUTH, EAST, WEST };

public class EnemyMovement : MonoBehaviour
{
 
    DIRECTION currentDirection = DIRECTION.SOUTH;
    Vector2 movement = new Vector2 (0, -1);

    [Range(0.01f, 0.1f)]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
        this.gameObject.transform.Translate(new Vector3(movement.x * speed, movement.y * speed, 0), Space.World);
    }

    void UpdateDirection()
    {
        switch(currentDirection)
        {
            case DIRECTION.EAST:
                movement = new Vector2(1, 0);
                break;

            case DIRECTION.NORTH:
                movement = new Vector2(0, 1);
                break;

            case DIRECTION.SOUTH:
                movement = new Vector2(0, -1);
                break;

            case DIRECTION.WEST:
                movement = new Vector2(0, -1);
                break;

            default:
                movement = new Vector2(0, 0);
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Turn Node")
            currentDirection = DIRECTION.EAST;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Turn Node")
            currentDirection = collision.GetComponent<Node>().setDirection;
    }
}
