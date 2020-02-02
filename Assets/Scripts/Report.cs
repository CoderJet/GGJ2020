using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report
{
    private float totalPossibleScore = 0;
    private float currentScore = 0;

    public void AddRobotScore(Robot rob)
    {
        totalPossibleScore += rob.totalValue;
        currentScore += rob.value;
    }

    public float GetStarRating()
    {
        return Mathf.Max((currentScore / totalPossibleScore) * 5, 0);
    }

    public string Remarks()
    {
        return "No remarks on your report card.";
    }
}
