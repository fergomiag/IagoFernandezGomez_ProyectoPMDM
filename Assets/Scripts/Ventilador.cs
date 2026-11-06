
using UnityEngine;

public class Ventilador : MonoBehaviour
{
    [SerializeField]
    float fuerzaAire = 8f;
    [SerializeField]
    AudioClip sonidoVentilador;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(sonidoVentilador);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb2d = collision.GetComponent<Rigidbody2D>();

            if (rb2d != null)
            {
                rb2d.linearVelocityY = fuerzaAire;
            }
        }
    }
}
