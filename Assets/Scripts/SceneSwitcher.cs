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
        SceneManager.LoadScene(1);
    }

    public static void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
