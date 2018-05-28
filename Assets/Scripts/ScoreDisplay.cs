using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text[] scoreTexts;
    public Text[] rollsTexts;

    public void FillRolls(List<int> rolls)
    {
        string scoreString = FormatRolls(rolls);
        for (int i = 0; i < scoreString.Length; i++)
        {
            rollsTexts[i].text = scoreString[i].ToString();
        }
    }

    public void FillFrames(List<int> rolls)
    {
        for(int i = 0; i < rolls.Count; i++)
        {
            scoreTexts[i].text = rolls[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";

        for (int i = 0; i < rolls.Count; i++)
        {
            if (rolls[i] == 10)
            {
                if(output.Length < 18)
                {
                    output = output + "X ";
                }
                else
                {
                    output = output + "X";
                }
            }
            else if (rolls.Count - 1 >= i + 1 && rolls[i] + rolls[i + 1] == 10 && (output.Length % 2 == 0  ||  output.Length == 20))
            {
                output = output + rolls[i].ToString() + "/";
                i++;
            }
            else
            {
                output = output + rolls[i].ToString();
            }
        }

        return output;
    }
}
