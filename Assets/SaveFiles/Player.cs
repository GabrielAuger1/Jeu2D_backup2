using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerHealth playerHealth;
    public int health;
    public float[] position = new float[3];
    void Update()
    {
        health = playerHealth.currentHealth;
        position[0] = rb.transform.position.x;
        position[1] = rb.transform.position.y;
        position[2] = rb.transform.position.z;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        rb.transform.position = position;
    }
}
