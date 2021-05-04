using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendScores : MonoBehaviour
{
    public static int numberOfSpins;
    public static void addScoreToLeaderboard()
    {
        Social.ReportScore(numberOfSpins, "CgkIiMHV2twCEAIQAA", success => { });
    }

    public static int setNumSpins(int spins)
    {
        numberOfSpins = spins;
        return numberOfSpins;
    }
}
