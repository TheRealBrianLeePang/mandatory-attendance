using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 3rd-person movement that picks direction relative to target (usually the camera)
// commented lines demonstrate snap to direction and without ground raycast
//
// To setup animated character create an animation controller with states for walking, interacting with object, and etc...
// transition between idle and running based on added Speed float, set those not atomic so that they can be overridden by...
// transition both idle and running to jump based on added Jumping boolean, transition back to idle

[RequireComponent(typeof(CharacterController))]


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float moveSpeed = 6.0f;
    public float rotSpeed = 15.0f;
    
    public float terminalVelocity = -20.0f;
    

   
    private ControllerColliderHit _contact;

    private CharacterController _charController;
    private Animator _animator;



    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // start with zero and add movement components progressively
        Vector3 movement = Vector3.zero;

        // x z movement transformed relative to target
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        if (horInput != 0 || vertInput != 0)
        {
            movement.x = horInput * moveSpeed;
            movement.z = vertInput * moveSpeed;
            movement = Vector3.ClampMagnitude(movement, moveSpeed);

            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = tmp;

            // face movement direction
            //transform.rotation = Quaternion.LookRotation(movement);
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation,
                                                 direction, rotSpeed * Time.deltaTime);


        }

        movement *= Time.deltaTime;
        _charController.Move(movement);

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;
    }
}
