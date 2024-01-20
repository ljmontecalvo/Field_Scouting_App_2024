using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = System.Object;

public class SuperObject : MonoBehaviour
{
    private static string FILE_PATH = Application.dataPath + "/Saves/";
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        for (var i = 0; i < CheckForSaves(); i++)
        {
            // TODO: Add profile creation here!
        }
    }

    private int CheckForSaves()
    {
        var counter = 0;
        while (true)
        {
            if (File.Exists(FILE_PATH + "/save" + counter + ".txt"))
            {
                counter++;
            }
            else break;
        }

        return counter;
    }
}
