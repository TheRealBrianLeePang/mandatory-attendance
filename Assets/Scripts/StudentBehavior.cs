using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentBehavior : MonoBehaviour
{

    [SerializeField] private float distance = 2.0f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject stairs;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Vector2.Distance(player.transform.position, transform.position) < distance)
        {
            stairs.SetActive(true);
            gameObject.SetActive(false);

            AudioSource[] audio = player.GetComponents<AudioSource>();
            AudioSource interactSound = audio[0];
            interactSound.Play();
        }
    }
}
