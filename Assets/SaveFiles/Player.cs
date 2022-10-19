using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerHealth playerHealth;
    public HealthBar healthBar;
    public int health;
    public float[] position = new float[3];

    public void SavePlayer()
    {
        health = playerHealth.currentHealth;
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.health;
        healthBar.SetHealth(health);
        playerHealth.currentHealth = health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        rb.transform.position = position;
    }
}
