using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public bool isPlayer1;
    public bool isPlayer2;
    public PlayerMove player;

    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyThrow;
    void Start()
    {   
        if(isPlayer1)
        {
            keyUp = KeyCode.W;
            keyDown = KeyCode.S;
            keyThrow = KeyCode.D;
        } else if(isPlayer2)
        {
            keyUp = KeyCode.P;
            keyDown = KeyCode.L;
            keyThrow = KeyCode.K;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(keyUp)) player.UpMove();
        if(Input.GetKey(keyDown)) player.DownMove();
        // if(Input.GetKey(keyThrow)) ;
    }


}
