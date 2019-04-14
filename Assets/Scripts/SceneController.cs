using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float timeRemaining;

 
    void OnGUI()
    {
        timeRemaining -= Time.deltaTime;
        GUI.color = Color.black;
        GUI.Label(new Rect(250, 250, 1000, 1000), "Time remaining: " + timeRemaining.ToString());
        if (timeRemaining <= 0)
        {
            Application.LoadLevel("GuardTest");
        }
    }
}
