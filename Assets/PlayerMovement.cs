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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // FixedUpdate est utilis� pour g�rer les physiques et simplifie l'usage de diverses fonctionalit�s
    void FixedUpdate()
    {
        //Le offset est d�fini arbitrairement pour d�terminer la distance de l'ajustement (servira plus tard).
        //Le if_else sert � ajuster la position du sprite lors d'un changement de direction.
        //Rb.velocity va changer la vitesse horizontale du joueur avec un Vecteur prenant en parametre dirX.

        dirX = Input.GetAxis("Horizontal");
        if ((dirX > 0 && faitFaceAGauche || dirX < 0 && !faitFaceAGauche))
        {
            float offset = 0.25f;
            if (dirX > 0)
            {
                transform.position = new Vector3(rb.position.x + offset, rb.position.y);
            }
            else if (dirX < 0)
            {
                transform.position = new Vector3(rb.position.x - offset, rb.position.y);

            }
            faitFaceAGauche = !faitFaceAGauche;
            transform.Rotate(new Vector3(0, 180, 0));
        }

        rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);

    }
}
