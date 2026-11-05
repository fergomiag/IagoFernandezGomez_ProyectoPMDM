using UnityEngine;

public class Ventilador : MonoBehaviour
{
    [SerializeField] float fuerzaAire = 8f;

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