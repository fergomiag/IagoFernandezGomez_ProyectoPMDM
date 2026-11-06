using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MovimientoJugador : MonoBehaviour
{
    InputAction movimientoAction;
    InputAction saltarAction;
    Rigidbody2D rb2d;
    BoxCollider2D collider2D;
    Animator animator;
    EstadisticasJuego estadisticas;

    [SerializeField]
    float velocidad = 5f;

    [SerializeField]
    float velocidadSalto = 5f;

    int numSaltos = 0;

    int estadoAnimacion = 0;

    bool recibiendoDano = false;

    int vidas = 3;

    bool muerto = false;

    Vector3 posicionInicial;
    Vector3 ultimoCheckpoint;

    public AudioSource sonidoSalto;
    public AudioSource sonidoDano;
    

    [SerializeField]
    float limiteCaida = -15f;

    [SerializeField]
    LayerMask suelo;

    void Start()
    {
        movimientoAction = InputSystem.actions.FindAction("Move");

        saltarAction = InputSystem.actions.FindAction("Jump");

        rb2d = GetComponent<Rigidbody2D>();

        collider2D = GetComponent<BoxCollider2D>();

        animator = GetComponent<Animator>();

        posicionInicial = transform.position;

        ultimoCheckpoint = posicionInicial;

        estadisticas = FindFirstObjectByType<EstadisticasJuego>();
        
        estadisticas.ActualizarVidas(vidas);
    }

    void Update()
    {
        if (muerto || recibiendoDano)
        {
            return;
        }

        if (transform.position.y < limiteCaida)
        {
            RecibirDano();
            return;
        }

        Moverse();
        Saltar();

        if (rb2d.linearVelocityY > 0.1f)
        {
            if (numSaltos == 2)
            {
                estadoAnimacion = 3;
            }
            else
            {
                estadoAnimacion = 2;
            }
        }
        else if (rb2d.linearVelocityY < -0.1f)
        {
            estadoAnimacion = 5;
        }
        else if (rb2d.linearVelocityX > 0)
        {
            estadoAnimacion = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb2d.linearVelocityX < 0)
        {
            estadoAnimacion = 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            estadoAnimacion = 0;
        }

        animator.SetInteger("estado", estadoAnimacion);
    }

    void Moverse()
    {
        Vector2 movimiento = movimientoAction.ReadValue<Vector2>();
        rb2d.linearVelocityX = movimiento.x * velocidad;
    }

    void Saltar()
    {
        if (saltarAction.WasPressedThisFrame())
        {
            if (EstaTocandoSuelo())
            {
                numSaltos = 0;
                rb2d.linearVelocityY = velocidadSalto;
                sonidoSalto.Play();
                numSaltos++;
            }
            else if (!EstaTocandoSuelo())
            {
                if (numSaltos < 2)
                {
                    rb2d.linearVelocityY = velocidadSalto;
                    sonidoSalto.Play();
                    numSaltos++;
                }
            }
        }
    }

    bool EstaTocandoSuelo()
    {
        return Physics2D.BoxCast(
            collider2D.bounds.center,
            collider2D.bounds.size,
            0f,
            Vector2.down,
            .1f,
            suelo
        );
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pinchos") && !recibiendoDano && !muerto)
        {
            vidas--;
            sonidoDano.Play();
            estadisticas.ActualizarVidas(vidas);

            if (vidas <= 0)
            {
                muerto = true;
                estadoAnimacion = 6;
                rb2d.linearVelocity = Vector2.zero;
                animator.SetInteger("estado", estadoAnimacion);

            }
            else
            {
                recibiendoDano = true;
                estadoAnimacion = 4;
                animator.SetInteger("estado", estadoAnimacion);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pinchos") && !muerto)
        {
            TerminarDano();
        }
    }

    public void TerminarDano()
    {
        if (!muerto)
        {
            transform.position = ultimoCheckpoint;

            rb2d.linearVelocity = Vector2.zero;

            numSaltos = 0;

            recibiendoDano = false;
        }
    }

    public void CargarEscenaMuerte()
    {
        SceneManager.LoadScene("Muerte");
    }

    public void GuardarCheckpoint(Vector3 posicion)
    {
        ultimoCheckpoint = posicion;
    }

    void RecibirDano()
    {
        if (!recibiendoDano && !muerto)
        {
            vidas--;
            sonidoDano.Play();
            estadisticas.ActualizarVidas(vidas);

            if (vidas <= 0)
            {
                muerto = true;
                estadoAnimacion = 6;

                rb2d.linearVelocity = Vector2.zero;

                animator.SetInteger("estado", estadoAnimacion);
            }
            else
            {
                recibiendoDano = true;

                rb2d.linearVelocity = Vector2.zero;

                estadoAnimacion = 4;

                animator.SetInteger("estado", estadoAnimacion);
            }
        }
    }
}
