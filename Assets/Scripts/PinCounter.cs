using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour
{
    public Text pinAmount;  //顯示剩餘數量的文字
    public int bowlStartPinCount;  //每一次擲球時場上的瓶子數

    private Game_Manager gameManager;
    private int lastStandingCount = -1;
    private bool ballLeftBox = false;  //球是否離開球道
    private float lastChangeTime;

    private void Start()
    {
        gameManager = FindObjectOfType<Game_Manager>();
        bowlStartPinCount = CountStanding();
    }
    private void Update()
    {
        int pinCount = CountStanding();
        pinAmount.text = pinCount.ToString();
        if (ballLeftBox)
        {
            CheckStanding();
        }
    }

    void CheckStanding()  //監控站著的瓶子數是否已經不再變動
    {
        int currentStanding = CountStanding();
        if (lastStandingCount != currentStanding)
        {
            lastStandingCount = currentStanding;
            lastChangeTime = Time.time;
            return;
        }
        float settleTime = 3.0f;
        if (Time.time - lastChangeTime > settleTime)
        {
            PinsHaveSettled();
        }
    }
    void PinsHaveSettled()  //球擊中瓶子之後瓶子存留數固定不再變動之後
    {
        int pinFall = bowlStartPinCount - lastStandingCount;
        bowlStartPinCount = lastStandingCount;
        gameManager.Bowl(pinFall);
        Debug.Log("Knocked down " + pinFall + " pin(s).");

        lastStandingCount = -1;
        ballLeftBox = false;
        pinAmount.color = Color.green;
    }

    public int CountStanding()  //計算目前站著的瓶子數目
    {
        int counter = 0;
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.isStanding())
            {
                counter++;
            }
        }
        return counter;
    }

    private void OnTriggerExit(Collider other)  //瓶子飛出之後摧毀瓶子
    {
        Pin pin = other.gameObject.GetComponentInParent<Pin>();
        if (pin)
        {
            Destroy(pin.gameObject);
        }

        if (other.GetComponent<Ball>())
        {
            ballLeftBox = true;
            pinAmount.color = Color.red;
        }
    }
}
