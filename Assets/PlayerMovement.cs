using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Les paramètres public peuvent se faire assigner des valeurs dans Unity
    public Rigidbody2D rb;
    public float dirX;
    public bool faitFaceAGauche;
    public float runSpeed;
    public bool isGrounded;
    private bool jumpButton;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.01f, groundLayer);
        jumpButton = Input.GetButtonDown("Jump");
        if (jumpButton && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.y, 5f);
        }

    }

    // FixedUpdate est utilisé pour gérer les physiques et simplifie l'usage de diverses fonctionalités
    void FixedUpdate()
    {
        //Le if_else sert à ajuster la position du sprite lors d'un changement de direction.
        //Rb.velocity va changer la vitesse horizontale du joueur avec un Vecteur prenant en parametre dirX.

        dirX = Input.GetAxis("Horizontal");
        if ((dirX > 0 && faitFaceAGauche || dirX < 0 && !faitFaceAGauche))
        {
            faitFaceAGauche = !faitFaceAGauche;
            transform.Rotate(new Vector3(0, 180, 0));
        }

        rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);

    }
}
