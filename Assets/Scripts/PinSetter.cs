using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    public GameObject pinSet;  //要產生的10個瓶子組
    public float distanceToRaise;  //整理球道時要將瓶子舉多高的距離

    private Animator animator;
    private PinCounter pinCounter;

    private void Start()
    {
        animator = GetComponent<Animator>();
        pinCounter = FindObjectOfType<PinCounter>();
    }

    public void PerformAction(ActionMaster2.Action action)
    {
        if (action == ActionMaster2.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
            Debug.Log("Tidy trigger triggered.");
        }
        else if (action == ActionMaster2.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.bowlStartPinCount = 10;  //reset 球道時場上瓶子數為10
            Debug.Log("Reset trigger triggered.");
        }
        else if (action == ActionMaster2.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.bowlStartPinCount = 10;  //reset 球道時場上瓶子數為10
            Debug.Log("Reset trigger triggered.");
        }
        else if (action == ActionMaster2.Action.EndGame)
        {
            throw new UnityException("not sure what to do yet");
        }
    }

    //PinSetter 動作
    private void RaisePins()
    {
        int counter = 0;
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.isStanding())
            {
                pin.transform.rotation = Quaternion.identity;
                pin.gameObject.transform.Translate(Vector3.up * distanceToRaise);
                pin.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                counter++;
            }
        }
    }
    private void LowerPins()
    {
        int counter = 0;
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.transform.position.y >= distanceToRaise)
            {
                pin.gameObject.transform.Translate(Vector3.down * distanceToRaise);
                pin.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                counter++;
            }
        }
    }
    private void RenewPins()
    {
        GameObject pins = Instantiate(pinSet, new Vector3(0f, distanceToRaise, 1839f), Quaternion.identity) as GameObject;
        foreach(Rigidbody body in pins.GetComponentsInChildren<Rigidbody>())
        {
            body.isKinematic = true;
        }
    }

    private void SwipePins()
    {
        Debug.Log("Swiping");
    }
}
