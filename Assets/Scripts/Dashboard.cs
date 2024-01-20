using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dashboard : MonoBehaviour
{
    public void StartScout()
    {
        // TODO: Check that fields have been filled out.
        SceneManager.LoadScene(1); // Load the scouting screen.
    }
}
