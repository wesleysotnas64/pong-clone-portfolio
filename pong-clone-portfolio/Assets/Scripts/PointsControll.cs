using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PointsControll : MonoBehaviour
{
    public int pointsPlayer1;
    public int pointsPlayer2;
    
    public TMP_Text txtPointsPlayer1;
    public TMP_Text txtPointsPlayer2; 

    public float player1XPosition;
    public float player2XPosition;
    public float distanceToScorePoint;
    public GameObject ballGameObject;
    public bool isPoint;

    void Start()
    {
        pointsPlayer1 = 0;
        pointsPlayer2 = 0;

        player1XPosition = GameObject.Find("Player_1").GetComponent<Transform>().position.x;
        player2XPosition = GameObject.Find("Player_2").GetComponent<Transform>().position.x;
        ballGameObject = GameObject.Find("Ball");

        isPoint = false;
    }

    void Update()
    {
        VerifyPoint();
    }

    public void ResetPoints()
    {
        pointsPlayer1 = 0;
        pointsPlayer2 = 0;
        txtPointsPlayer1.text = $"{pointsPlayer1}";
        txtPointsPlayer2.text = $"{pointsPlayer2}";
        ballGameObject.GetComponent<Ball>().Reset();
        isPoint = false;
    }

    public void UpPointsPlayer1()
    {
        pointsPlayer1++;
        txtPointsPlayer1.text = $"{pointsPlayer1}";
        ballGameObject.GetComponent<Ball>().Reset();
        isPoint = false;
    }

    public void UpPointsPlayer2()
    {
        pointsPlayer2++;
        txtPointsPlayer2.text = $"{pointsPlayer2}";
        ballGameObject.GetComponent<Ball>().Reset();
        isPoint = false;
    }

    public void VerifyPoint()
    {
        if(isPoint == false)
        {
            if(ballGameObject.transform.position.x < player1XPosition - distanceToScorePoint)
            {
                isPoint = true;
                UpPointsPlayer2();
            } else if(ballGameObject.transform.position.x > player2XPosition + distanceToScorePoint)
            {
                isPoint = true;
                UpPointsPlayer1();
            }
        }
    }
}
