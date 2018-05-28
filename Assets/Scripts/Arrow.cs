using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Ball ball;
    private bool isMovingRight, isMovingLeft;
    

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        isMovingLeft = isMovingRight = false;
    }
    private void Update()
    {
        if(isMovingRight)
        {
            MoveHorzintal(1f);
        }
        if(isMovingLeft)
        {
            MoveHorzintal(-1f);
        }
    }

    public void MoveHorzintal(float amount)
    {
        float newX = ball.transform.position.x + amount;
        ball.transform.position = new Vector3(Mathf.Clamp(newX, -52.5f, 52.5f), ball.transform.position.y, ball.transform.position.z);
        //Debug.Log("ball moved " + amount);
    }

    public void ChangeBool(string direction)
    {
        if(direction == "left")
        {
            isMovingLeft = !isMovingLeft;
        }
        if(direction == "right")
        {
            isMovingRight = !isMovingRight;
        }
    }
}
