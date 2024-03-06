using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    // Método que se llama cuando otro objeto colisiona con este objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión es con una pared
        if (collision.gameObject.CompareTag("Pared"))
        {
            // Llamar a un método para manejar la muerte del jugador
            Morir();
        }
    }

    // Método para manejar la muerte del jugador
    private void Morir()
    {
        // Por ahora simplemente desactivamos el objeto del jugador
        gameObject.SetActive(false);

        // Reiniciar la escena después de un breve retraso (opcional)
        Invoke("ReiniciarEscena", 2f);
    }

    // Método para reiniciar la escena
    private void ReiniciarEscena()
    {
        // Obtener el índice de la escena actual
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;

        // Recargar la escena actual
        SceneManager.LoadScene(indiceEscenaActual);
    }
}
