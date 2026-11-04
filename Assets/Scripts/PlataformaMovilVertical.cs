using UnityEngine;

public class PlataformaMovilVertical : MonoBehaviour
{
    Rigidbody2D rb2d;

    float velocidad = 2f;
    float limiteSuperior = 6f;
    float limiteInferior = 3f;

    int direccion = 1;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.linearVelocityY = velocidad * direccion;

        if (transform.position.y >= limiteSuperior)
        {
            direccion = -1;
        }
        else if (transform.position.y <= limiteInferior)
        {
            direccion = 1;
        }
    }
}