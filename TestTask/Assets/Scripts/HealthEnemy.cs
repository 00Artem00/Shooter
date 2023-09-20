using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private ParticleSystem _particleSystem; 

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        _particleSystem.Play();

        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
