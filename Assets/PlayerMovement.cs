using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Les param�tres public peuvent se faire assigner des valeurs dans Unity
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

        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.25f, groundLayer);
        jumpButton = Input.GetButtonDown("Jump");
        if (jumpButton && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.y, 5f);
        }
    }

    // FixedUpdate est utilis� pour g�rer les physiques et simplifie l'usage de diverses fonctionalit�s
    void FixedUpdate()
    {
        //Le if_else sert � ajuster la position du sprite lors d'un changement de direction.
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
