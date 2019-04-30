using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSight : MonoBehaviour
{

    [SerializeField] private float distance;
    [SerializeField] private GameObject player;
    [SerializeField] private Gradient okColor;
    [SerializeField] private Gradient cautionColor;
    [SerializeField] private Gradient dangerColor;
    [SerializeField] private GameObject deathAudio;

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
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
            if (hit.collider.CompareTag("Player"))
            {
                if(Vector2.Distance(transform.position, hit.point) <= distance)
                {
                    //Debug.DrawLine(transform.position, hit.point, Color.red);
                    lineRenderer.colorGradient = dangerColor;
                    AudioSource[] audio = deathAudio.GetComponents<AudioSource>();
                    AudioSource scream = audio[Random.Range(0, audio.Length-1)];
                    StartCoroutine(PlayerCharacter.Die(player, initialPlayerPosition, scream));
                }
                else
                { 
                    lineRenderer.colorGradient = cautionColor;
                    //Debug.DrawLine(transform.position, hit.point, Color.yellow);
                }
            }
            else
            {
                lineRenderer.colorGradient = okColor;
                //Debug.DrawLine(transform.position, hit.point, Color.green);
            }
        }
    }
}
