
using UnityEngine;
using TMPro;

public class EstadisticasJuego : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public TextMeshProUGUI textoVidas;
    public AudioClip sonidoFruta;

    AudioSource audioSource;
    int contadorMelon;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SumarMelon()
    {
        contadorMelon++;
        texto.text = contadorMelon.ToString();

        audioSource.PlayOneShot(sonidoFruta);
    }

    public void ActualizarVidas(int vidas)
    {
        textoVidas.text = vidas.ToString();
    }
}
