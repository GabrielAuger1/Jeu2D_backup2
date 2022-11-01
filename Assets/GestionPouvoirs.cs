using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GestionPouvoirs : MonoBehaviour
{
    [SerializeField] private float dashDownTimer;
    [SerializeField] private float dashLeftTimer;
    [SerializeField] private float dashRightTimer;
    [SerializeField] private float freezeTimer;
    [SerializeField] private float gravityTimer;
    [SerializeField] private float dashCoolDown;
    private Rigidbody2D rb;
    private PlayerMovement PlayerMovement;
    private PlayerHealth PlayerHealth;

    private void Awake()
    {
        gravityTimer = 0;
        dashCoolDown = 120;
        rb = GetComponent<Rigidbody2D>();
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        #region SIDE_DASH
        bool collidingWall = PlayerMovement.wallCollide;
        bool isGrounded = PlayerMovement.isGrounded;
        freezeTimer--;
        gravityTimer--;
        if (Input.GetKeyDown("j"))
        {
            dashLeftTimer = dashCoolDown;
            freezeTimer = 20;
        }
        if (Input.GetKeyDown("k"))
        {
            dashDownTimer = dashCoolDown;
            freezeTimer = 20;
        }
        if (Input.GetKeyDown("l"))
        {
            dashRightTimer = dashCoolDown;
            freezeTimer = 20;
        }
        if (freezeTimer > 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.gravityScale = 0;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            if (dashDownTimer > 0 && !isGrounded)
            {
                rb.transform.position += new Vector3(0f, -0.013f, 0.00001f * Time.deltaTime);
                gravityTimer = 25;
            }
            else if (dashLeftTimer > 0 && !collidingWall)
            {
                rb.transform.position += new Vector3(-0.013f, 0.0f, 0.00001f * Time.deltaTime);
                gravityTimer = 25;
            }
            else if (dashRightTimer > 0 && !collidingWall)
            {
                rb.transform.position += new Vector3(0.013f, 0.0f, 0.00001f * Time.deltaTime);
                gravityTimer = 25;
            }

            dashDownTimer--;
            dashLeftTimer--;
            dashRightTimer--;
        }
        if (gravityTimer > 0)
        {
            PlayerMovement.runSpeed = 0;
            rb.gravityScale = 0.5f;
            PlayerHealth.damage = 0;
            gameObject.layer = 10;
        }
        else if (gravityTimer <= 0)
        {
            PlayerMovement.runSpeed = 3;
            rb.gravityScale = 2;
            PlayerHealth.damage = 1;
            gameObject.layer = 6;
        }
        #endregion

    }
}
