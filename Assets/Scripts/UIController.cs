using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadInstructions()
    {
        Application.LoadLevel("Instructions");
    }

    public void GoToStart()
    {
        Application.LoadLevel("Start");
    }
}
