using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;
    public int currentHealth;
    public int damage;
    private Transform wallCheckRight;
    private Transform wallCheckLeft;
    public bool wallCollide;
    public bool playerCollide;
    public bool playerAttackingCollide;
    public LayerMask attackingPlayerLayer;
    public LayerMask playerLayer;
    private LayerMask groundLayer;
    private float distanceX;
    Rigidbody2D rb;
    public float invTimer;

    private void Awake()
    {
        #region InitializeComponents
        target = GameObject.FindGameObjectWithTag("Player").transform;
        wallCheckRight = GameObject.Find("RightWallCheck").transform;
        wallCheckLeft = GameObject.Find("LeftWallCheck").transform;
        groundLayer = LayerMask.GetMask("Ground");
        playerLayer = LayerMask.GetMask("Player");
        attackingPlayerLayer = LayerMask.GetMask("AttackingPlayer");
        rb = GetComponent<Rigidbody2D>();
        currentHealth = 4;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement
        wallCollide = Physics2D.OverlapCircle(wallCheckLeft.transform.position, 0.01f, groundLayer) || Physics2D.OverlapCircle(wallCheckRight.transform.position, 0.01f, groundLayer);
        playerAttackingCollide = Physics2D.OverlapCircle(wallCheckLeft.transform.position, 0.01f, attackingPlayerLayer) || Physics2D.OverlapCircle(wallCheckRight.transform.position, 0.01f, attackingPlayerLayer);
        playerCollide = Physics2D.OverlapCircle(wallCheckLeft.transform.position, 0.01f, playerLayer) || Physics2D.OverlapCircle(wallCheckRight.transform.position, 0.01f, playerLayer);
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
        if (playerCollide)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (playerAttackingCollide)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        #endregion

        #region Health

        if (playerAttackingCollide && invTimer <= 0)
        {
            currentHealth -= 1;
            if (currentHealth <= 0)
            {
                GameObject.Destroy(gameObject);
            }
            invTimer = 50;
        }
        invTimer--;

        #endregion
    }
}
