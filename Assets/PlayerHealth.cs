using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    public int damage;
    // Start is called before the first frame update
    void Awake()
    {
        healthBar = FindObjectOfType<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name == "Square")
        {
            TakeDamage(damage);
        }
    }
}
