using UnityEngine;

public class CuchillaGiratoria : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField]
    float velocidadCaida = 6f;
    [SerializeField]
    float velocidadHorizontal = 5f;
    float velocidadGiro = 360f;

    Vector3 posicionInicial;

    bool enSuelo = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (!enSuelo)
        {
            rb2d.linearVelocity = new Vector2(0, -velocidadCaida);
        }
        else
        {
            rb2d.linearVelocity = new Vector2(velocidadHorizontal, 0);
        }

        transform.Rotate(0, 0, -velocidadGiro * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            transform.position = posicionInicial;
            rb2d.linearVelocity = Vector2.zero;
            enSuelo = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("suelo"))
        {
            enSuelo = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("suelo"))
        {
            enSuelo = false;
        }
    }
}