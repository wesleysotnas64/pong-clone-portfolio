using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 direction;
    public float baseSpeed;
    public float limitSpeed;
    public float currentSpeed;
    public float speedPercentage;
    public Vector2 initialPosition;
    public bool idle;
    public List<Vector2> initialDirections;
    public List<int> directionsToPlayer1Bounce;
    public List<int> directionsToPlayer2Bounce;
    

    void Start()
    {
        initialPosition = new Vector2(transform.position.x, transform.position.y);
        InitInitialDirections();
        Reset();
    }

    void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.Space) && idle) RandomInitialDirection();
    }

    private void Move()
    {
        transform.Translate(direction*currentSpeed*Time.deltaTime, 0);
    }

    private void UpSpeed()
    {
        if (currentSpeed < limitSpeed) currentSpeed *= speedPercentage;
        else currentSpeed = limitSpeed;
    }

    public void Reset()
    {
        currentSpeed = baseSpeed;
        transform.position = initialPosition;
        direction = Vector2.zero;
        idle = true;
    }

    private void RandomInitialDirection()
    {
        direction = initialDirections[Random.Range(0, initialDirections.Count)];        

        transform.position = transform.position + new Vector3(0, Random.Range(-3, 3), 0);

        idle = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Player":
                if (direction.x < 0)
                {
                    direction = initialDirections[directionsToPlayer1Bounce[Random.Range(0, directionsToPlayer1Bounce.Count)]];
                }
                else
                {
                    direction = initialDirections[directionsToPlayer2Bounce[Random.Range(0, directionsToPlayer2Bounce.Count)]];
                }
                UpSpeed();
                break;
            
            case "Wall":
                direction = ReflectDirection(direction.normalized, col.gameObject.transform.up);
                break;

            default:
                break;
        }
    }

    private Vector2 ReflectDirection(Vector2 _direction, Vector2 _normal)
    {
        return _direction - 2 * Vector2.Dot(_direction, _normal) * _normal;
    }

    private void InitInitialDirections()
    {
        //Cardinais principais
        Vector2 north = new Vector2(0, 1).normalized;
        Vector2 south = new Vector2(0, -1).normalized;
        Vector2 east = new Vector2(1, 0).normalized;
        Vector2 west = new Vector2(-1, 0).normalized;
        
        //Cardinais intermediários
        Vector2 northeast = new Vector2(1, 1).normalized;
        Vector2 northwest = new Vector2(-1, 1).normalized;
        Vector2 southeast = new Vector2(1, -1).normalized;
        Vector2 southwest = new Vector2(-1, -1).normalized;

        // Intermediários entre cardinais e intermediários
        Vector2 north_northeast = (north + northeast).normalized;
        Vector2 east_northeast = (northeast + east).normalized;
        Vector2 east_southeast = (east + southeast).normalized;
        Vector2 south_southeast = (southeast + south).normalized;
        Vector2 south_southwest = (south + southwest).normalized;
        Vector2 west_southwest = (southwest + west).normalized;
        Vector2 west_northwest = (west + northwest).normalized;
        Vector2 north_northwest = (northwest + north).normalized;

        initialDirections = new List<Vector2>
        {
            northeast, //0 ->
            northwest, //1 
            southeast, //2 ->
            southwest, //3
            north_northeast, //4 ->
            east_northeast,  //5 ->
            east_southeast,  //6 ->
            south_southeast, //7 ->
            south_southwest, //8
            west_southwest,  //9
            west_northwest,  //10
            north_northwest  //11
        };

        directionsToPlayer1Bounce = new List<int>()
        {
            0, 2, 4, 5, 6, 7
        };

        directionsToPlayer2Bounce = new List<int>()
        {
            1, 3, 8, 9, 10, 11
        };
        
    }
}
