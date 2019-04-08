using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitioningCamera : MonoBehaviour
{
    [SerializeField] private float[] angleTransitions;
    [SerializeField] private float waitTime;
    [SerializeField] private GameObject player;
    private float currTime = 0;
    private Vector2 initialPos;
    private int i = 0;

    void Start()
    {
        initialPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 100);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                player.transform.position = initialPos;
            }
            else
            {
                Debug.DrawLine(transform.position, hit.point, Color.green);
            }
        }

        if (currTime >= waitTime)
        {
            currTime = 0;
            transform.Rotate(0, 0, angleTransitions[i]);
            i++;
            if(i >= angleTransitions.Length)
            {
                i = 0;
            }
        }
    }
}
