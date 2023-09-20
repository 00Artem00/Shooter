using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Text healthCount;
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void TakeDamage(float damage)
    {   
        if (currentHealth - damage <= 0)
        {
            healthCount.text = "X 0";
            CharacterInputController.alive = false;
        }
        else
        {
            currentHealth -= damage;
            healthCount.text = "X " + currentHealth.ToString();
        }   
    }
}
