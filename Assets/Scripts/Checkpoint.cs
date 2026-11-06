
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform puntoReaparicion;
    public AudioClip sonidoCheckpoint;

    Animator animacion;
    AudioSource audioSource;
    bool activado = false;

    void Start()
    {
        animacion = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
                audioSource.PlayOneShot(sonidoCheckpoint);

                activado = true;
            }
        }
    }
}
