using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{


    public void BotonVolverAJugar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void BotonSalir()
    {
        SceneManager.LoadScene("Menu");
    }
}
