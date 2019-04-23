using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float timeRemaining;
    [SerializeField] private Font font;
    [SerializeField] private string sceneName;
 
    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        timeRemaining -= Time.deltaTime;
        GUI.color = Color.white;
        GUI.skin.font = font;
        GUI.Label(new Rect(150, 150, 2000, 2000), "Time remaining: " + timeRemaining.ToString(), style);
        if (timeRemaining <= 0)
        {
            Application.LoadLevel(sceneName);
        }
    }
}
