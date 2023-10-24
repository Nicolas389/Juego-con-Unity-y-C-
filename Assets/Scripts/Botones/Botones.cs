using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
   
    public void IrAlJuego()
    {

        SceneManager.LoadScene("Juego");
    }

    public void CerrarJuego()
    {
        Application.Quit();
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("Pantalla Inicial");
    }
}
