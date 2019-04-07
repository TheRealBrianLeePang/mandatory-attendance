using UnityEngine;
using System.Collections;

// maintains position offset while orbiting around target

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;


    private Vector3 _offset;

    // Use this for initialization
    void Start()
    {
 
        _offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position - _offset;
        transform.LookAt(target);
    }
}