using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWheelText : MonoBehaviour
{
    public List<string> Games_in_list;
    public List<Text> gamesAsText;
    
    // Start is called before the first frame update
    void Start()
    {
        //int i = 0;
        //while(i<12)
        //{
        //    Games_in_list[i] = UserDefinedGames.GameList[i];
        //    gamesAsText[i].text = Games_in_list[i];
        //    i++;
        //}

        //this is obviously messy, the order i added the input fields in was messed up and this was faster to do than trace each inputfield.
        //the ideal implementation is seen above
        Games_in_list[0] = UserDefinedGames.GameList[4];
        Games_in_list[1] = UserDefinedGames.GameList[5];
        Games_in_list[2] = UserDefinedGames.GameList[6];
        Games_in_list[3] = UserDefinedGames.GameList[7];
        Games_in_list[4] = UserDefinedGames.GameList[8];
        Games_in_list[5] = UserDefinedGames.GameList[9];
        Games_in_list[6] = UserDefinedGames.GameList[10];
        Games_in_list[7] = UserDefinedGames.GameList[11];
        Games_in_list[8] = UserDefinedGames.GameList[0];
        Games_in_list[9] = UserDefinedGames.GameList[1];
        Games_in_list[10] = UserDefinedGames.GameList[2];
        Games_in_list[11] = UserDefinedGames.GameList[3];
        int i = 0;
        while(i<12)
        {
            gamesAsText[i].text = Games_in_list[i];
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
