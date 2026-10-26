using UnityEngine;
public class AnimacionMelon : MonoBehaviour
{
    Animator animacion;
    int estadoAnimacion;
    EstadisticasJuego estadisticas;

    void Start()
    {
        animacion = GetComponent<Animator>();
        estadisticas = FindFirstObjectByType<EstadisticasJuego>();
    }

    void Update()
    {
        animacion.SetInteger("estado", estadoAnimacion);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estadoAnimacion = 1;
            estadisticas.SumarMelon();
        }
    }

    void DestruirObjeto()
    {
        Destroy(gameObject);
    }
}
