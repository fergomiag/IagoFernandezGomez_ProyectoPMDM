
using UnityEngine;

public class PlataformaSalto : MonoBehaviour
{
    Animator animator;

    float fuerzaSalto = 12f;

    void Start()
    {
        animator = GetComponent<Animator>();
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
            }
        }
    }
}
