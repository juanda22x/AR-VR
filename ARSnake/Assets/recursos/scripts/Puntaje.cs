using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    // Variable para almacenar la puntuaci�n
    private int puntuacion = 0;

    // Referencia al objeto TextMeshPro para mostrar la puntuaci�n
    public TextMeshProUGUI textoPuntuacion;

    // M�todo que se llama cuando se recoge la manzana
    private void Recoger()
    {
        // Sumar 5 puntos
        puntuacion += 5;
        // Actualizar la visualizaci�n de la puntuaci�n
        ActualizarPuntuacion();
        // Destruir la manzana
        Destroy(gameObject);
    }

    // M�todo para actualizar la visualizaci�n de la puntuaci�n
    private void ActualizarPuntuacion()
    {
        // Verificar si hay una referencia al objeto TextMeshPro
        if (textoPuntuacion != null)
        {
            // Actualizar el texto con la puntuaci�n actualizada
            textoPuntuacion.text = "Puntuaci�n: " + puntuacion.ToString();
        }
    }

    // M�todo que se llama cuando otro objeto colisiona con este objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisi�n es con un objeto llamado "Player" (o el objeto del jugador)
        if (collision.gameObject.tag == "Player")
        {
            // Llamar al m�todo Recoger cuando se colisiona con el jugador
            Recoger();
        }
    }
}
