
using UnityEngine;

public class PlataformaSalto : MonoBehaviour
{
    public AudioClip sonidoPlataforma;

    Animator animator;
    AudioSource audioSource;

    float fuerzaSalto = 12f;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb2d = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb2d != null)
            {
                rb2d.linearVelocityY = fuerzaSalto;

                animator.SetTrigger("ActivarSalto");

                audioSource.PlayOneShot(sonidoPlataforma);
            }
        }
    }
}
