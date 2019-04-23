using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{

    [SerializeField] private float rotationRate;
    [SerializeField] private GameObject player;
    [SerializeField] private Gradient okColor;
    [SerializeField] private Gradient dangerColor;
    [SerializeField] private float minAngle = 0;
    [SerializeField] private float maxAngle = 360;
    [SerializeField] private GameObject deathAudio;

    private float currentAngle = 0;
    private Vector2 initialPos;
    private LineRenderer lineRenderer;

    private int incrementFactor = 1;

    void Start()
    {
        initialPos = player.transform.position;
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 100);
        if (hit.collider != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
            if (hit.collider.CompareTag("Player"))
            {
                lineRenderer.colorGradient = dangerColor;
                AudioSource[] audio = deathAudio.GetComponents<AudioSource>();
                AudioSource scream = audio[Random.Range(0, audio.Length-1)];
                scream.Play();
                player.transform.position = initialPos;
            }
            else
            {
                lineRenderer.colorGradient = okColor;
            }
        }

        transform.Rotate(0, 0, incrementFactor * rotationRate);
        currentAngle += incrementFactor * rotationRate;

        if(currentAngle >= maxAngle || currentAngle <= minAngle )
        {
            incrementFactor *= -1;
        }
    }
}
