using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Like playerMovement but on a different plane, used for test purposes only
public class PlayerMovementXY : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float moveSpeed = 6000.0f;
    public float rotSpeed = 15.0f;
    
    public float terminalVelocity = -20.0f;

    private bool isColliding;
    private Rigidbody2D rigidbody;
   
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // start with zero and add movement components progressively
        Vector3 movement = Vector3.zero;

        // x z movement transformed relative to target
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        if (horInput != 0 || vertInput != 0)
        {
            movement.x = horInput * moveSpeed;
            movement.y = vertInput * moveSpeed;
            movement = Vector3.ClampMagnitude(movement, moveSpeed);

            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = tmp;

            /*
            //face movement direction
            transform.rotation = Quaternion.LookRotation(movement);
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation,
                                                 direction, rotSpeed * Time.deltaTime);
            */

        }

        // Slightly "bounce" off the walls if colliding
        if (isColliding)
        {
            movement *= -3;
            isColliding = false;
        }

        movement *= Time.deltaTime;
        rigidbody.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        transform.position += movement * moveSpeed;
    }

    //Unity doesn't have 2D character colliders and using all rigidbodies makes things weird, 
    //so I have to use trigger detection for collision handling
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entering: " + collision);
        isColliding = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exiting: " + collision);
        isColliding = false;
    }

}