using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public List<int> pinFalls = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;
    private DragLaunch dragLaunch;
    private ScoreDisplay scoreDisplay;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();  //找球
        dragLaunch = FindObjectOfType<DragLaunch>();  //找發射板
        pinSetter = FindObjectOfType<PinSetter>();
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl(int pinFall)
    {
        pinFalls.Add(pinFall);
        ActionMaster2.Action nextAction = ActionMaster2.NextAction(pinFalls);
        pinSetter.PerformAction(nextAction);
        try
        {
            scoreDisplay.FillRolls(pinFalls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(pinFalls));
        }
        catch
        {
            Debug.LogWarning("Something went wrong in Bowl()");
        }
        ball.Reset();
        dragLaunch.Reset();
    }

}
