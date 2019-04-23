using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBehavior : MonoBehaviour
{
    [SerializeField] private float distance = 2.0f;
    [SerializeField] private GameObject player;
    [SerializeField] private string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Vector2.Distance(player.transform.position, transform.position) < distance)
        {
            Debug.Log("Stairs used");
            AudioSource[] audio = player.GetComponents<AudioSource>();
            AudioSource interactSound = audio[0];
            interactSound.Play();
            Application.LoadLevel(nextScene);
        }

    }
  }
