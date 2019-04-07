using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;

    void Start()
    {
        _health = 1;
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log("Health: " + _health);
    }
}
