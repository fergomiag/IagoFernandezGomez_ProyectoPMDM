using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PortalVictoria : MonoBehaviour
{
    public AudioClip sonidoPortal;

    AudioSource audioSource;
    bool activado = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !activado)
        {
            activado = true;
            StartCoroutine(CambiarEscena());
        }
    }

    IEnumerator CambiarEscena()
{
    Rigidbody2D rb = FindFirstObjectByType<MovimientoJugador>().GetComponent<Rigidbody2D>();

    rb.linearVelocity = Vector2.zero;
    rb.simulated = false;

    if (sonidoPortal != null && audioSource != null)
    {
        audioSource.PlayOneShot(sonidoPortal);
    }

    yield return new WaitForSeconds(0.5f);

    SceneManager.LoadScene("Win");
}
}