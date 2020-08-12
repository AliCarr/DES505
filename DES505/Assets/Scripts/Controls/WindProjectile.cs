using UnityEngine;

public class WindProjectile : MonoBehaviour
{
    public Transform enemyTransform;
    // Start is called before the first frame update
    public float buildingRange;

    private Vector2 initialPosition;
    private float distanceTravelled;
    // Update is called once per frame

    private void Start()
    {
        initialPosition = transform.position;

    }
    void Update()
    {
        transform.Translate(Vector3.left*Time.deltaTime);
        distanceTravelled = Vector2.Distance(transform.position, initialPosition);
        if (distanceTravelled >= buildingRange)
        {
            Destroy(gameObject);
        }
        
    }
}
