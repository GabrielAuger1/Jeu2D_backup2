using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Les paramètres public peuvent se faire assigner des valeurs dans Unity
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

    // FixedUpdate est utilisé pour gérer les physiques et simplifie l'usage de diverses fonctionalités
    void FixedUpdate()
    {
        //Le offset est défini arbitrairement pour déterminer la distance de l'ajustement (servira plus tard).
        //Le if_else sert à ajuster la position du sprite lors d'un changement de direction.
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
