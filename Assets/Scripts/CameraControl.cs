using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Ball ball;

    private Vector3 distanceBetweenBall;
    void Start()
    {
        distanceBetweenBall = ball.transform.position - transform.position;
    }

    void Update()
    {
        if (ball.transform.position.z <= 1800f)
        {
            transform.position = ball.transform.position - distanceBetweenBall;
        }
    }
}


