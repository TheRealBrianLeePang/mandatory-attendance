using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public Transform startPoint;
    public Transform endPoint;
    private LineRenderer lr;
    


    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetWidth(.2f, .2f);
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, startPoint.position);
        lr.SetPosition(1, endPoint.position);
    }
}
