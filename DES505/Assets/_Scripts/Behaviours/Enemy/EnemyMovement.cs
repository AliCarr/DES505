using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION { NORTH, SOUTH, EAST, WEST };

public class EnemyMovement : MonoBehaviour
{
    private Vector2 movement = new Vector2(0, -1);

    [Range(0.1f, 10.0f)]
    public float speed;
    public DIRECTION currentDirection;


    void Update()
    {
        UpdateDirection();
        this.gameObject.transform.Translate(new Vector3(movement.x * speed *Time.unscaledDeltaTime, movement.y * speed * Time.unscaledDeltaTime, 0), Space.World);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Turn Node")
            currentDirection = collision.GetComponent<Node>().setDirection;

        if(collision.gameObject.tag == "Forest")
        {
            Destroy(this.gameObject);
        }
    }
}
