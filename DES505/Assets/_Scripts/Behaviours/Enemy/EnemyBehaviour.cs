using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private const float Amount = 1.0f;
    [Range(0.1f, 3.0f)]
    public float speed;
    public TemperatureScript temperature;
    public SPScripts sciencePoints;
    public Animator enemyExpressions;
    public AudioSource enemySpawnSound;

    private Transform[] waypoints;
    private int waypointIndex = 0;

    public int health;
    public int damage;
    public int value;

    private float initialSpeed;
    private bool isSlowed = false;
    private bool isHealthNotZero = true;
    void Start()
    {
        temperature = UIManager.Instance.TemperaturScript();
        sciencePoints = UIManager.Instance.SPScript();
        initialSpeed = speed;
        enemyExpressions = GetComponent<Animator>();
    }

    public void SetWaypoints(Transform[] newWayPoints)
    {
        waypoints = newWayPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (waypointIndex <= waypoints.Length - 1)
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


        if(isHealthNotZero)
        {
            if (health <= 0)
            {
                enemyExpressions.SetInteger("State", 2);
                temperature.DecreaseTemperature(Amount);
                sciencePoints.IncreaseSciencePoints(20);
                StartCoroutine(DieOverTime());
                isHealthNotZero = false;
            }
        }
    }


    public void TakeDamage(int amount)
    {
        if (health > 0)
        {
            health -= amount;
            enemyExpressions.SetInteger("State", 1);
            StartCoroutine(ReinstateExpression());
        }
    }

    public void ReduceSpeed(float amount)
    {
        if (speed - amount > 0.1f)
        {
            if (!isSlowed)
            {
                enemyExpressions.SetInteger("State", 1);
                StartCoroutine(SlowInTimeInterval(amount));
            }
        }
    }

    private IEnumerator SlowInTimeInterval(float amount)
    {
        isSlowed = true;
        speed -= amount;
        yield return new WaitForSeconds(2.0f);
        ReinstateSpeed();
    }

    public void ReinstateSpeed()
    {
        speed = initialSpeed;
        enemyExpressions.SetInteger("State", 0);
    }
    int DoDamage()
    {
        return damage;
    }

    private IEnumerator ReinstateExpression()
    {
        yield return new WaitForSeconds(1.0f);
        enemyExpressions.SetInteger("State", 0);
    }

    private IEnumerator DieOverTime()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }

}
