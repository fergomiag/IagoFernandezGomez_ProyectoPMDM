using UnityEngine;
using TMPro;

public class EstadisticasJuego : MonoBehaviour
{
    public TextMeshProUGUI texto;
    int contadorMelon;

    public void SumarMelon()
    {
        contadorMelon++;
        texto.text = contadorMelon.ToString();
    }
    
}
