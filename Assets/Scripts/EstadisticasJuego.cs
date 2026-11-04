using UnityEngine;
using TMPro;

public class EstadisticasJuego : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public TextMeshProUGUI textoVidas;
    int contadorMelon;

    public void SumarMelon()
    {
        contadorMelon++;
        texto.text = contadorMelon.ToString();
    }

    public void ActualizarVidas(int vidas)
    {
        textoVidas.text = vidas.ToString();
    }
    
}
