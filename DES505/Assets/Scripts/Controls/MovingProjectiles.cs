using UnityEngine;

public class MovingProjectiles : MonoBehaviour
{
    public Transform enemyTransform;
    public float speed = 5f;
    
    void Update()
    {
        
        //transform.LookAt(enemyTransform, Vector3.right);
        if (enemyTransform != null)
        {
            transform.Rotate(0.0f, 0.0f, Vector2.SignedAngle(transform.position, -transform.position + enemyTransform.position), Space.Self);
            transform.position = Vector2.MoveTowards(transform.position, enemyTransform.position, speed * Time.deltaTime);
            if (transform.position == enemyTransform.position)
            {
               Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
