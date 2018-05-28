using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest
{
    private List<int> pinFalls;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    [SetUp]  //每次[Test]前都會執行Setup內的東西
    public void Setup()
    {
        pinFalls = new List<int>();
    }

    [Test]  //個別測試
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01FirstStrickResultsEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02Bowl8ResultsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T03Bowl28SpareResultsEndTurn()
    {
        int[] rolls = { 2, 8 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T04Bowl452ResultsEndTidy()
    {
        int[] rolls = { 4, 5, 2 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T05BowlStrike4ResultsTidy()
    {
        int[] rolls = { 10, 4 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T06Bowl64SpareStrikeResultsEndTurn()
    {
        int[] rolls = { 6, 4, 10 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T07Bowl9StrikesInNinthFrameResultsEndTurn()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10 };  //9個擲球數
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T08TenthFrameBowlStrikesAtTheFirstTryResultsReset()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10};  //10個擲球數
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T09NoStrikeOrSpareAtLastFrameResultsEndGame()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1 };  //11個擲球數
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T10TenthFrameBowlSpareResultsReset()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 5, 5 };  //11個擲球數
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T11TenthFrameBowlStrikesTwiceResultsReset()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };  //11個擲球數
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T12BowlStrikes12TimesResultsEndGame()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };  //12個擲球數
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T13NoSparesOrStrikesThroughEntireGameResultsEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };  //20個擲球數
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T14TenthFrameFirstStrikeThenBowl5ResultsTidy()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5 };  //20個擲球數
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T15Bowl0Strikes9TimesResultsEndTurn()
    {
        int[] rolls = { 0, 10, 5, 1 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T16LastFrameTurkey()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10 };  //20個擲球數
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
}
