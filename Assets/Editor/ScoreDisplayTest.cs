using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest
{
    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01Bowl1()
    {
        int[] rolls = { 1 };
        string rollstring = "1";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T02BowlX()
    {
        int[] rolls = { 10 };
        string rollstring = "X ";  //X後面有空格
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T03Bowl55()
    {
        int[] rolls = { 5, 5 };
        string rollstring = "5/";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T04Bowl333()
    {
        int[] rolls = { 3, 3, 3 };
        string rollstring = "333";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T05BowlX1()
    {
        int[] rolls = { 10, 1 };
        string rollstring = "X 1";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T06BowlX64()
    {
        int[] rolls = { 10, 6, 4 };
        string rollstring = "X 6/";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T07BowlAll1()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };  //20個1
        string rollstring = "11111111111111111111";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T08BowlXX()
    {
        int[] rolls = { 10, 10 };
        string rollstring = "X X ";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T09Bowl1237X()
    {
        int[] rolls = { 1, 2, 3, 7, 10 };
        string rollstring = "123/X ";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T10BowlAllSpare()
    {
        int[] rolls = { 0, 10,    1, 9,    2, 8,    3, 7,    4, 6,    5, 5,    6, 4,    7, 3,    8, 2,    9, 1 };  //20個數字
        string rollstring = "0/1/2/3/4/5/6/7/8/9/";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T11Bowl9X()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10 };  //9個數字
        string rollstring = "X X X X X X X X X ";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Category("tenth frame")]
    [Test]
    public void T12BowlLastFrameNoSpareNoStrike()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1 };  //11個數字
        string rollstring = "X X X X X X X X X 11";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Category("tenth frame")]
    [Test]
    public void T13Bowl12X()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };  //12個數字
        string rollstring = "X X X X X X X X X XXX";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Category("tenth frame")]
    [Test]
    public void T14BowlLastFrameSpare()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 5, 5, 5 };  //12個數字
        string rollstring = "X X X X X X X X X 5/5";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Category("tenth frame")]
    [Test]
    public void T15BowlLastFrameSpareAndStrike()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 6, 4, 10 };  //12個數字
        string rollstring = "X X X X X X X X X 6/X";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void TG00GoldenCopyTest()
    {
        int[] rolls = { 9, 0, 10 };
        string rollstring = "90X ";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG01GoldenCopyB1of3()
    {
        int[] rolls = { 10, 9, 1, 9, 1, 9, 1, 9, 1, 7, 0, 9, 0, 10, 8, 2, 8, 2, 10 };
        string rollsString = "X 9/9/9/9/7090X 8/8/X";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG02GoldenCopyB2of3()
    {
        int[] rolls = { 8, 2, 8, 1, 9, 1, 7, 1, 8, 2, 9, 1, 9, 1, 10, 10, 7, 1 };
        string rollsString = "8/819/718/9/9/X X 71";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyB3of3()
    {
        int[] rolls = { 10, 10, 9, 0, 10, 7, 3, 10, 8, 1, 6, 3, 6, 2, 9, 1, 10 };
        string rollsString = "X X 90X 7/X 8163629/X";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    // http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    [Category("Verification")]
    [Test]
    public void TG04GoldenCopyC1of3()
    {
        int[] rolls = { 7, 2, 10, 10, 10, 10, 7, 3, 10, 10, 9, 1, 10, 10, 9 };
        string rollsString = "72X X X X 7/X X 9/XX9";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    // http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    [Category("Verification")]
    [Test]
    public void TG05GoldenCopyC2of3()
    {
        int[] rolls = { 10, 10, 10, 10, 9, 0, 10, 10, 10, 10, 10, 9, 1 };
        string rollsString = "X X X X 90X X X X X9/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Category("Verification")]
    [Test]
    public void TG04LastFrame919()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 1, 9 };
        string rollstring = "1111111111111111119/9";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));

    }
}
