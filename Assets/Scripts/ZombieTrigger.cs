using System;
using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{
    private AIZombie _zombie;

    private void Awake()
    {
        _zombie = GetComponentInParent<AIZombie>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _zombie.HasAttack)
        {
            GameManager.Instance.Death();
        }
    }
}