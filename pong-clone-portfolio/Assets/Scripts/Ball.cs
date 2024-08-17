using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 direction;
    public float baseSpeed;
    public float limitSpeed;
    public float currentSpeed;
    public float speedPercentage;
    public Vector2 initialPosition;

    

    void Start()
    {
        initialPosition = new Vector2(transform.position.x, transform.position.y);
        Reset();
    }

    void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.Space)) RandomInitialDirection();
        if(Input.GetKeyDown(KeyCode.R)) Reset();
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
    }

    private void RandomInitialDirection()
    {
        do
        {
            direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            direction = direction.normalized;

        } while (IsInvalidDirection(direction));
    }

    private bool IsInvalidDirection(Vector2 direction)
    {
        return (Mathf.Approximately(direction.x, 1f) && Mathf.Approximately(direction.y, 0f)) ||
            (Mathf.Approximately(direction.x, -1f) && Mathf.Approximately(direction.y, 0f)) ||
            (Mathf.Approximately(direction.x, 0f) && Mathf.Approximately(direction.y, 1f)) ||
            (Mathf.Approximately(direction.x, 0f) && Mathf.Approximately(direction.y, -1f));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Player":
                direction = ReflectDirection(direction.normalized, col.gameObject.transform.right);
                break;
            
            case "Wall":
                direction = ReflectDirection(direction.normalized, col.gameObject.transform.up);
                break;

            default:
                break;
        }

        UpSpeed();
    }

    private Vector2 ReflectDirection(Vector2 _direction, Vector2 _normal)
    {
        return _direction - 2 * Vector2.Dot(_direction, _normal) * _normal;
    }
}
