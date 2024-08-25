using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControll : MonoBehaviour
{
    public PlayerMove player2Move;
    public Transform player2Transform;
    public Joystick player2Joystick;
    public Transform ball;
    public bool isAI;

    public UnityEngine.UI.Image btnP2Image;
    public UnityEngine.UI.Image btnAIImage;
    
    void Start()
    {
        player2Move = GameObject.Find("Player_2").GetComponent<PlayerMove>();
        player2Joystick = GameObject.Find("Joystick_2").GetComponent<Joystick>();
        ball = GameObject.Find("Ball").GetComponent<Transform>();
        player2Transform = GameObject.Find("Player_2").transform;
        isAI = false;
        SetAsP2();
    }

    
    void Update()
    {
        AIMove();
    }

    public void AIMove()
    {
        if(isAI)
        {
            
            if(ball.position.y > player2Transform.position.y) player2Move.UpMove();
            if(ball.position.y < player2Transform.position.y) player2Move.DownMove();
        }
    }

    public void SetAsAI()
    {
        isAI = true;
        player2Joystick.player = null;

        btnAIImage.color = new Color(1, 1, 1, 1.0f);
        btnP2Image.color = new Color(1, 1, 1, 0.1f);
    }

    public void SetAsP2()
    {
        isAI = false;
        player2Joystick.player = player2Move;
        btnAIImage.color = new Color(1, 1, 1, 0.1f);
        btnP2Image.color = new Color(1, 1, 1, 1.0f);
    }
}
