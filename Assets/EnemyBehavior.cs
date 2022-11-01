using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;
    public int maxHealth;
    public int damage;
    private Transform wallCheckRight;
    private Transform wallCheckLeft;
    public bool wallCollide;
    private Transform groundCheck;
    private LayerMask groundLayer;
    private float distanceX;
    Rigidbody2D rb;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        wallCheckRight = GameObject.Find("RightWallCheck").transform;
        wallCheckLeft = GameObject.Find("LeftWallCheck").transform;
        groundCheck = GameObject.Find("GroundCheck").transform;
        groundLayer = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        wallCollide = Physics2D.OverlapCircle(wallCheckLeft.transform.position, 0.01f, groundLayer) || Physics2D.OverlapCircle(wallCheckRight.transform.position, 0.01f, groundLayer);
        distanceX = target.position.x - gameObject.transform.position.x;
        Vector2 targetX = new Vector2(target.position.x, transform.position.y);
        if (distanceX > -2.4 && distanceX < 2.4)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            transform.position = Vector2.MoveTowards(transform.position, targetX, 0.0025f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (wallCollide)
        {
            rb.velocity = new Vector2(0, 5f);
        }
    }
}
