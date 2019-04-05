using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Simple cyclic patrolling script for guard.
 */
public class GuardMovement : MonoBehaviour
{

    [SerializeField] private Transform[] guardPositions;
    [SerializeField] private float speed;

    private int i = 0;
    private Vector2 nextPosition;

    private Vector2 originalPosition;

    void Start()
    {
        originalPosition = this.transform.position;
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
            if(i >= guardPositions.Length)
            {
                i = 0;
            }
            else
            {
                i++;
            }
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
