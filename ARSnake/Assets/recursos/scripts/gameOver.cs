using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    // M�todo que se llama cuando otro objeto colisiona con este objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisi�n es con una pared
        if (collision.gameObject.CompareTag("Pared"))
        {
            // Llamar a un m�todo para manejar la muerte del jugador
            Morir();
        }
    }

    // M�todo para manejar la muerte del jugador
    private void Morir()
    {
        // Por ahora simplemente desactivamos el objeto del jugador
        gameObject.SetActive(false);

        // Reiniciar la escena despu�s de un breve retraso (opcional)
        Invoke("ReiniciarEscena", 2f);
    }

    // M�todo para reiniciar la escena
    private void ReiniciarEscena()
    {
        // Obtener el �ndice de la escena actual
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;

        // Recargar la escena actual
        SceneManager.LoadScene(indiceEscenaActual);
    }
}
