using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserDefinedGames : MonoBehaviour
{
    public List<string> listOfGames;
    public InputField Game1, Game2, Game3, Game4, Game5, Game6, Game7, Game8, Game9, Game10, Game11, Game12;
    public List<InputField> InputFieldsTemp;
    public static List<string> GameList;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        GameList = listOfGames;
    }

    public void UpdateGamesList()
    {
        InputFieldsTemp.Add(Game1);
        InputFieldsTemp.Add(Game2);
        InputFieldsTemp.Add(Game3);
        InputFieldsTemp.Add(Game4);
        InputFieldsTemp.Add(Game5);
        InputFieldsTemp.Add(Game6);
        InputFieldsTemp.Add(Game7);
        InputFieldsTemp.Add(Game8);
        InputFieldsTemp.Add(Game9);
        InputFieldsTemp.Add(Game10);
        InputFieldsTemp.Add(Game11);
        InputFieldsTemp.Add(Game12);

        int i = 0;
        while (i<12)
        {
            InputField temp = InputFieldsTemp[i];
            listOfGames.Add(temp.text);

            Debug.Log(listOfGames[i]);
            i++;
        }
        Debug.Log(GameList.Count + " is the size of the list");
    }
}
