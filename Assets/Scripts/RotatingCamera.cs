using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{

    [SerializeField] private float rotationRate;
    [SerializeField] private GameObject player;
    [SerializeField] private Gradient okColor;
    [SerializeField] private Gradient dangerColor;

    private float currentAngle = 0;
    private Vector2 initialPos;
    private LineRenderer lineRenderer;

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
                player.transform.position = initialPos;
            }
            else
            {
                lineRenderer.colorGradient = okColor;
            }
        }

        transform.Rotate(0, 0, rotationRate);
        currentAngle += rotationRate;
    }
}
