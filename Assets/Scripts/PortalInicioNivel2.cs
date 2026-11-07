using UnityEngine;

public class PortalInicioNivel2 : MonoBehaviour
{
    public AudioClip sonidoPortal;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (sonidoPortal != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoPortal);
        }
    }
}