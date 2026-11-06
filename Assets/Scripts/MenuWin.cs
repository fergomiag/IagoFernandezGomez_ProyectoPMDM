using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWin : MonoBehaviour
{
    public void BotonSalir()
    {
        SceneManager.LoadScene("Menu");
    }
}
