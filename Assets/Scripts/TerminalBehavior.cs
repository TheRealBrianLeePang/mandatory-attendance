using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalBehavior : MonoBehaviour
{

    [SerializeField] GameObject controlledObject;
    [SerializeField] GameObject player;
    [SerializeField] float distance = 2.0f;
    [SerializeField] bool shouldMakeActive = false;

    // Update is called once per frame
    void Update()
    {
        if (shouldMakeActive)
        {
            controlledObject.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Space) && Vector2.Distance(player.transform.position, transform.position) < distance)
        {
            controlledObject.SetActive(shouldMakeActive);
            shouldMakeActive = !shouldMakeActive;
            gameObject.SetActive(false);
        }
    }
}
