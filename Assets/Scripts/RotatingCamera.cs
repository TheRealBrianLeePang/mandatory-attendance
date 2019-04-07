using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{

    [SerializeField] private float rotationRate;

    private float currentAngle = 0;
  
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 100);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
            }
            else
            {
                Debug.DrawLine(transform.position, hit.point, Color.green);
            }
        }

        transform.Rotate(0, 0, rotationRate);
        currentAngle += rotationRate;
    }
}
