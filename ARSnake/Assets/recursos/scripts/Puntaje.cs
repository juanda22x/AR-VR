using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    // Variable para almacenar la puntuación
    private int puntuacion = 0;

    // Referencia al objeto TextMeshPro para mostrar la puntuación
    public TextMeshProUGUI textoPuntuacion;

    // Método que se llama cuando se recoge la manzana
    private void Recoger()
    {
        // Sumar 5 puntos
        puntuacion += 5;
        // Actualizar la visualización de la puntuación
        ActualizarPuntuacion();
        // Destruir la manzana
        Destroy(gameObject);
    }

    // Método para actualizar la visualización de la puntuación
    private void ActualizarPuntuacion()
    {
        // Verificar si hay una referencia al objeto TextMeshPro
        if (textoPuntuacion != null)
        {
            // Actualizar el texto con la puntuación actualizada
            textoPuntuacion.text = "Puntuación: " + puntuacion.ToString();
        }
    }

    // Método que se llama cuando otro objeto colisiona con este objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión es con un objeto llamado "Player" (o el objeto del jugador)
        if (collision.gameObject.tag == "Player")
        {
            // Llamar al método Recoger cuando se colisiona con el jugador
            Recoger();
        }
    }
}
