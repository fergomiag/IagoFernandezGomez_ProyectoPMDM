using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    public Transform puntoReaparicion;
    Animator animacion;
    bool activado = false;

    void Start()
    {
        animacion = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !activado)
        {
            MovimientoJugador jugador = collision.GetComponent<MovimientoJugador>();


            if (jugador != null)
            {
                jugador.GuardarCheckpoint(puntoReaparicion.position);
                animacion.SetBool("activado", true);
                activado = true;
            }
        }
    }
}