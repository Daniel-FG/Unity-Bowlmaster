using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class ScoreMaster
{
    public static List<int> ScoreCumulative(List<int> rolls)  //回傳每一局的累計分數
    {
        List<int> cumulativeScore = new List<int>();
        int totalScore = 0;
        foreach(int roll in ScoreFrames(rolls))
        {
            totalScore = totalScore + roll;
            cumulativeScore.Add(totalScore);
        }
        return cumulativeScore;
    }
    public static List<int> ScoreFrames(List<int> rolls)  //回傳每局分數的函式
    {
        List<int> frameList = new List<int>();  //計算出來的每局分數加入此List
        
        for (int i = 0; i < rolls.Count; i = i + 2)  //一次迴圈掃過每局擲球2次成績  若當局未打完兩次或全倒則用下方if跳出
        {
            if (rolls.Count - 1 < i + 1)  //for迴圈的條件是每次+2  如果沒有足夠的擲球數的話就跳出
                break;

            if (rolls[i] + rolls[i + 1] < 10)  //沒有全倒也沒有半倒的狀況
            {
                frameList.Add(rolls[i] + rolls[i + 1]);  //將當局內的兩次擲球相加作為當局分數
            }

            //如果後面沒有兩次擲球成績則不紀錄成績
            if (rolls.Count - 1 < i + 2)  
                break;
            if (rolls[i] == 10)  //全倒的狀況
            {
                frameList.Add(10 + rolls[i + 1] + rolls[i + 2]);
                if (frameList.Count != 10)  //撇除最後一局第一次擊球即全倒的狀況
                {
                    i = i - 1;  //for迴圈的條件是每次+2  事先減1才能從下一次擲球成績看起
                }
            }
            else if (rolls[i] + rolls[i + 1] == 10)  //半倒
            {
                frameList.Add(10 + rolls[i + 2]);
            }
        }
        return frameList;
    }
}
