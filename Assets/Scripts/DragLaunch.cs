using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    public GameObject touchInput;
    public GameObject arrowPanel;

    private Ball ball;
    private Vector3 touchPosition, releasePosition;
    private float startTime, endTime;
    private void Start()
    {
        ball = GetComponent<Ball>();
    }
    public void DragStart()
    {
        touchPosition = Input.mousePosition;
        startTime = Time.time;
    }
    public void DragEnd()
    {
        releasePosition = Input.mousePosition;
        endTime = Time.time;
        float dragDuration = endTime - startTime;
        float launchSpeedX = (releasePosition.x - touchPosition.x) / dragDuration;
        float launchSpeedZ = (releasePosition.y - touchPosition.y) / dragDuration;
        Vector3 launchVelocity = new Vector3(launchSpeedX, 0f, launchSpeedZ);
        ball.Launch(launchVelocity);

        touchInput.SetActive(false);
        arrowPanel.SetActive(false);
    }
    public void Reset()
    {
        touchInput.SetActive(true);
        arrowPanel.SetActive(true);
    }
}
