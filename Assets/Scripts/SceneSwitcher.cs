using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static void loadWheelScene()
    {
        SceneManager.LoadScene(2);
    }

    public static void loadMainMenu()   //this should say load selectionscene
    {
        Social.ReportProgress("CgkIiMHV2twCEAIQAg", 100, success => { });
        SceneManager.LoadScene(1);
    }
    public static void loadFirstMenu()
    {
        SceneManager.LoadScene(0);
    }
    public static void loadLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }
    public static void loadAchievements()
    {
        Social.ShowAchievementsUI();
    }
}
