using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContadorManzanas : MonoBehaviour
{
    public TMP_Text textoContador;
    private int contadorManzanas = 0;

    public void IncrementarContador()
    {
        contadorManzanas++;
        ActualizarTextoContador();
    }

    void ActualizarTextoContador()
    {
        textoContador.text = "Manzanas: " + contadorManzanas.ToString();
    }
}
