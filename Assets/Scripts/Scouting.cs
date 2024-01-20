using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scouting : MonoBehaviour
{
    private static string FILE_PATH = Application.dataPath + "/Saves/";
    
    public GameObject[] screens;
    
    [Header("Auto Components")]
    public Counter[] autoCounters;
    public TMP_Dropdown[] autoDropdowns;
    public Toggle[] autoCheckboxes;
    
    [Header("Teleop Components")]
    public Counter[] teleopCounters;
    public TMP_Dropdown[] teleopDropdowns;
    public Toggle[] teleopCheckboxes;

    public void AutoBackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void TeleopBackButton()
    {
        for (var i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(i + 1 == 1);
        }
    }

    public void AutoNextButton()
    {
        for (var i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(i + 1 == 2);
        }
    }

    public void TeleopNextButton()
    {
        var saveString = string.Join(SaveAuto(), SaveTeleop());
        
        // Check is save file number already exists, and then changes it is necessary.
        if (!PlayerPrefs.HasKey("saveNumber")) PlayerPrefs.SetInt("saveNumber", 0);
        while (File.Exists(FILE_PATH + "/save" + PlayerPrefs.GetInt("saveNumber") + ".txt")) PlayerPrefs.SetInt("saveNumber", PlayerPrefs.GetInt("saveNumber") + 1);
        
        // Writes file.
        File.WriteAllText(FILE_PATH + "/save" + PlayerPrefs.GetInt("saveNumber") + ".txt", saveString);
        
        SceneManager.LoadScene(0);
    }

    private string SaveAuto()
    {
        var autoObjs = new List<int>();
        
        // Assign values for text inputs.
        autoObjs.AddRange(autoCounters.Select(obj => obj.count).ToList());
        
        // Assign values for dropdowns.
        autoObjs.AddRange(autoDropdowns.Select(obj => obj.value));
        
        // Assign values for checkboxes.
        foreach (var obj in autoCheckboxes)
        {
            switch (obj.isOn)
            {
                case true: autoObjs.Add(1); break;
                case false: autoObjs.Add(0); break;
            }
        }

        // Concatenate list into one string for saving.
        var saveString = autoObjs.Aggregate("", (current, obj) => current + obj + ",");

        return saveString;
    }

    private string SaveTeleop()
    {
        var teleopObjs = new List<int>();
        
        // Assign values for text inputs.
        teleopObjs.AddRange(autoCounters.Select(obj => obj.count).ToList());
        
        // Assign values for dropdowns.
        teleopObjs.AddRange(teleopDropdowns.Select(obj => obj.value));
        
        // Assign values for checkboxes.
        foreach (var obj in teleopCheckboxes)
        {
            switch (obj.isOn)
            {
                case true: teleopObjs.Add(1); break;
                case false: teleopObjs.Add(0); break;
            }
        }

        // Concatenate list into one string for saving.
        var saveString = teleopObjs.Aggregate("", (current, obj) => current + obj + ",");

        return saveString;
    }
}
