using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;
    private static bool isAlreadyDying = false;
    private static Animator AnAnimator;

    void Start()
    {
        _health = 1;
        AnAnimator = GetComponent<Animator>();
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log("Health: " + _health);
    }

    //stuff to do when the player dies
    public static IEnumerator Die(GameObject player, Vector3 initialPos, AudioSource deathSfx)
    {
        Debug.Log("player dying");
        if (!isAlreadyDying)
        {
            deathSfx.Play();
        }
        isAlreadyDying = true;
        player.GetComponent<PlayerMovementXY>().enabled = false;
        yield return new WaitForSeconds(1f);
        AnAnimator.SetBool("killed", false);
        player.transform.position = initialPos;
        isAlreadyDying = false;
        player.GetComponent<PlayerMovementXY>().enabled = true;
    }
}
