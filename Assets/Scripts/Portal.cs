using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Portal : MonoBehaviour
{
    public AudioClip sonidoPortal;

    AudioSource audioSource;
    bool activado = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !activado)
        {
            activado = true;
            StartCoroutine(CambiarEscena());
        }
    }

    IEnumerator CambiarEscena()
    {
        if (sonidoPortal != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoPortal);
            yield return new WaitForSeconds(sonidoPortal.length);
        }

        if (SceneManager.GetActiveScene().name == "Nivel1")
        {
            SceneManager.LoadScene("Nivel2");
        }
    }
}