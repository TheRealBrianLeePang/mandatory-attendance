using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitioningCamera : MonoBehaviour
{
    [SerializeField] private float[] angleTransitions;
    [SerializeField] private float waitTime;
    [SerializeField] private GameObject player;
    [SerializeField] private Gradient okColor;
    [SerializeField] private Gradient dangerColor;
    [SerializeField] private GameObject deathAudio;

    private float currTime = 0;
    private Vector2 initialPos;
    private int i = 0;
    private LineRenderer lineRenderer;

    void Start()
    {
        initialPos = player.transform.position;
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 100);
        if (hit.collider != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
            if (hit.collider.CompareTag("Player"))
            {
                lineRenderer.colorGradient = dangerColor;
                AudioSource[] audio = deathAudio.GetComponents<AudioSource>();
                AudioSource scream = audio[Random.Range(0, audio.Length-1)];
                StartCoroutine(PlayerCharacter.Die(player, initialPos, scream));
            }
            else
            {
                lineRenderer.colorGradient = okColor;
            }
        }

        if (currTime >= waitTime)
        {
            currTime = 0;
            transform.Rotate(0, 0, angleTransitions[i]);
            i++;
            if(i >= angleTransitions.Length)
            {
                i = 0;
            }
        }
    }

   
}
