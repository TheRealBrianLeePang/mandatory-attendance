using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Simple cyclic patrolling script for guard.
 */
public class GuardMovement : MonoBehaviour
{
    // Positions that the guard should cycle between
    [SerializeField] private Transform[] guardPositions;
    // Angles that the guard should rotate along z-axis to keep line of sight, once reach the above positions.
    // Should be the same length as guardPositions -- not great code, but works for now
    [SerializeField] private float[] transformAngles;
    // The angle to rotate once you finish the cycle
    [SerializeField] private float firstAngle;
    // The speed to move at
    [SerializeField] private float speed;

    private int i = 0;
    private Vector2 previousPosition;
    private Vector2 nextPosition;

    private Vector2 originalPosition;

    void Start()
    {
        originalPosition = this.transform.position;
        previousPosition = originalPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 nextPosition = GetNextPosition();
        this.transform.position =
           Vector2.MoveTowards(
             this.transform.position,
             nextPosition,
             speed * Time.deltaTime);

        if (hasArrived(nextPosition, 0.05f))
        {
            i = i >= guardPositions.Length? 0 : ++i;
            float rotationAngle = nextPosition.Equals(originalPosition) ? transformAngles[i] : firstAngle;
            transform.Rotate(0, 0, rotationAngle);


            previousPosition = this.transform.position;
        }
    }

    private Vector2 GetNextPosition()
    {
        if (i >= guardPositions.Length)
        {
            nextPosition = originalPosition;
            if(hasArrived(originalPosition, 0.05f))
            {
                i = 0;
            }
        }
        else
        {
            nextPosition = guardPositions[i].position;
        }
        return nextPosition;
    }

    private bool hasArrived(Vector2 position, float threshold) 
    {
        return Vector2.Distance(this.transform.position, position) < threshold;
    }
}
