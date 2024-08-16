using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 direction;
    public float speed;

    void Start()
    {
        RandomInitialDirection();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(direction*speed*Time.deltaTime, 0);
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
    }

    private Vector2 ReflectDirection(Vector2 _direction, Vector2 _normal)
    {
        return _direction - 2 * Vector2.Dot(_direction, _normal) * _normal;
    }
}
