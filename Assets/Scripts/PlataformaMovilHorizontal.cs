using UnityEngine;

public class PlataformaMovilHorizontal : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField] float velocidad = 2f;
    [SerializeField] float limiteDerecho = 5f;
    [SerializeField] float limiteIzquierdo = 0f;

    int direccion = 1;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb2d.position.x >= limiteDerecho)
        {
            direccion = -1;
        }
        else if (rb2d.position.x <= limiteIzquierdo)
        {
            direccion = 1;
        }

        rb2d.linearVelocityX = velocidad * direccion;
    }
}