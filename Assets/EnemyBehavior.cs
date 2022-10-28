using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private bool PlayerInRange;
    [SerializeField] private float DistanceX;
    [SerializeField] private float DistanceY;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (player != null)
        {
            Debug.Log("player found");
        }
    }

    private void Update()
    {

        DistanceX = gameObject.transform.position.x - player.position.x;
        DistanceY = gameObject.transform.position.y - player.position.y;

        if (DistanceX < 2.47 && DistanceX > -2.47 && DistanceY < 1.3 && DistanceY > -1.3)
        {
            PlayerInRange = true;
            PlayerDetected();
            if (DistanceX > 0)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.0034f, gameObject.transform.position.y);
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.0034f, gameObject.transform.position.y);
            }
        }
        else
        {
            PlayerInRange = false;
            PlayerLost();
        }
    }
    private void PlayerDetected()
    {
        spriteRenderer.color = Color.red;
    }
    private void PlayerLost()
    {
        spriteRenderer.color = Color.blue;
    }
}
