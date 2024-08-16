using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float yLimit;

    public void UpMove()
    {
        if(transform.position.y < yLimit) Move(1);
    }

    public void DownMove()
    {
        if(transform.position.y > -yLimit) Move(-1);
    }

    private void Move(int direction = 1)
    {
        transform.Translate(0, direction * speed * Time.deltaTime, 0);
    }
}
