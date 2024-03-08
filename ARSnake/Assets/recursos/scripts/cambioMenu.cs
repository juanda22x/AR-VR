using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioMenu : MonoBehaviour
{
    // Método para cambiar de escena
    public void Jugar(string Juego)
    {
        SceneManager.LoadScene(Juego);
    }

    public void Prueba(string prueba1)
    {
        SceneManager.LoadScene(prueba1);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("cierra juego");
    }
}

