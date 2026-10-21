using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    InputAction movimientoAction;
    InputAction saltarAction;
    Rigidbody2D rb2d;
    BoxCollider2D collider2D;

    [SerializeField]
    float velocidad = 5f;

    [SerializeField]
    float velocidadSalto = 5f;

    int numSaltos = 0;

    [SerializeField]
    LayerMask suelo;
    
    void Start()
    {
        movimientoAction = InputSystem.actions.FindAction("Move");

        saltarAction = InputSystem.actions.FindAction("Jump");
        
        rb2d = GetComponent<Rigidbody2D>();

        collider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Moverse();
        Saltar();
    }

    void Moverse()
    {
        Vector2 movimiento = movimientoAction.ReadValue<Vector2>();
        rb2d.linearVelocityX = movimiento.x * velocidad;  
    }

    void Saltar()
    {
        if (EstaTocandoSuelo())
        {
            numSaltos = 0;
        }

        if (saltarAction.WasPressedThisFrame() && numSaltos < 2)
        {
            rb2d.linearVelocityY = velocidadSalto;
            numSaltos++;
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
}
