using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSight : MonoBehaviour
{

    [SerializeField] private float distance;
    [SerializeField] private GameObject player;
    LineRenderer lineRenderer;
    Vector2 initialPlayerPosition;


    // Start is called before the first frame update
    void Start()
    {
        initialPlayerPosition = player.transform.position;
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("transform.right = " + transform.right);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 100);
        //Debug.Log("Hit.point=" + hit.point);
        //Debug.Log("transform.position=" + transform.position);
        //Debug.DrawLine(transform.position, hit.point, Color.green);
        //Debug.Log(transform.right);
        if(hit.collider != null) {
            if (hit.collider.CompareTag("Player"))
            {
                if(Vector2.Distance(transform.position, hit.point) <= distance)
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                    player.transform.position = initialPlayerPosition;
                }
                else
                {
                    Debug.DrawLine(transform.position, hit.point, Color.yellow);
                }
            }
            else
            {
                Debug.DrawLine(transform.position, hit.point, Color.green);
            }
        }
    }
}
