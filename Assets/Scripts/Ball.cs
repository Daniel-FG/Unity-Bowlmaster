using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool inPlay = false;
    private Rigidbody ball;
    private AudioSource rollingSound;
    private Vector3 initialPosition;

    private void Start()
    {
        ball = GetComponent<Rigidbody>();
        rollingSound = GetComponent<AudioSource>();
        initialPosition = transform.position;
        ball.useGravity = false;
    }

    public void Launch(Vector3 launchSpeed)
    {
        inPlay = true;
        ball.useGravity = true;
        ball.velocity = launchSpeed;
        rollingSound.Play();
    }
    public void Reset()
    {
        inPlay = true;
        transform.position = initialPosition;
        ball.velocity = ball.angularVelocity = Vector3.zero;
        ball.useGravity = false;
    }
    public void AutoFire()
    {
        Launch(new Vector3(0, 0, 1500));
    }
}
