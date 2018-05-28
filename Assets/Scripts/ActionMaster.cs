using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
    public enum Action {Tidy, Reset, EndTurn, EndGame };

    private int[] bowls = new int[21];
    private int bowl = 1;  //丟出保齡球的次數

    public static Action NextAction(List<int> pinFalls)
    {
        ActionMaster actionMaster = new ActionMaster();
        Action nextAction = new Action();
        foreach (int pinFall in pinFalls)
        {
            nextAction = actionMaster.Bowl(pinFall);
        }
        return nextAction;
    }

    public Action Bowl(int pins)
    {
        if(pins > 10 || pins < 0)  //檢查瓶子的數量是否正確
        {
            throw new UnityException("Invalid pin count");  //瓶子數量不正確
        }
        else
        {
            bowls[bowl - 1] = pins;  //將瓶子擊倒數紀錄在陣列對應擲球數的位置
        }

        //最後一局
        if (bowl == 21)  //最後一局結束之後結束遊戲
        {
            return Action.EndGame;
        }

        if (bowl >= 19 && Bowl21Awarded())  //最後一局19, 20, 21
        {
            bowl++;
            if(bowls[19 - 1] + bowls[20 - 1] == 10)  //第十局擲到半倒
            {
                return Action.Reset;
            }
            //第十局第一球(第19次擲球)全倒(獲得第21次擲球)  但第20次擲球沒有全倒
            else if (bowls[19 - 1] + bowls[20 - 1] < 20 && bowls[19 - 1] + bowls[20 - 1] > 10)  
            {
                return Action.Tidy;
            }
            return Action.Reset;
        }
        else if (bowl == 20 && !Bowl21Awarded())  //第十局沒有全倒也沒有半倒
        {
            return Action.EndGame;
        }



        //1~9局


        if (bowl % 2 != 0)  //如果在每一局的第一次丟球機會丟出不是全倒的數量
        {
            if (pins == 10)  //檢查第一次是不是擊出全倒
            {
                bowl = bowl + 2;  //進行到下一局  一局有兩次丟球機會而第一次丟出全倒則沒有第二次丟球機會  直接進行到下一局
                return Action.EndTurn;  //直接進行到下一局
            }
            else
            {
                bowl++;  //進行當局的第二次丟球
                return Action.Tidy;  //清理球道
            }
        }
        else if (bowl % 2 == 0)  //每一局的第二次丟球結束後
        {
            bowl++;
            return Action.EndTurn;  //結束本局
        }
        throw new UnityException("not sure what to return!");
    }

    private bool Bowl21Awarded()  //如果在第19, 20次擲球有擲出全倒或是半倒則獎勵玩家第21次擲球
    {
        if (bowls[19 - 1] + bowls[20 - 1] >= 10)  //將兩次擲球結果相加
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
