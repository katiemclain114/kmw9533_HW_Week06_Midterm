using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
    private const string DIR = "/Logs";
    private const string FILE_ASCII = DIR + "/test.txt";
    public string FILE_PATH_ASCII;

    //prefab for plant spot game object
    public GameObject plantSpot;

    private void Start()
    {
        FILE_PATH_ASCII = Application.dataPath + FILE_ASCII;
        LoadLevel();
    }

    void LoadLevel()
    {
        int i = 0;
        string[] fileLines = File.ReadAllLines(FILE_PATH_ASCII);
        for (int y = 0; y < fileLines.Length; y++)
        {
            //only needs to place one type of gameobject so char doesnt need switch
            string lineText = fileLines[y];
            char[] characters = lineText.ToCharArray();
            for (int x = 0; x < characters.Length; x++)
            {
                GameObject newObj;
                newObj = Instantiate<GameObject>(plantSpot);
                //make new key for each spot so saves for individual plantspot
                newObj.GetComponent<PlantSpot>().PREF_KEY_PLANT = "plantKey" + i;
                i++;//add to i so next plant key is one more
                if (newObj != null)
                {
                    //transform doubled for better spacing
                    newObj.transform.position = new Vector2((x + x), -(y + y));
                }
            }
        }
    }
    
    
}
