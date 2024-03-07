using UnityEngine;

public class GeneradorManzanas : MonoBehaviour
{
    public GameObject objetoPrefab; // El objeto que quieres generar
    public int cantidadObjetos = 10; // La cantidad de objetos que quieres generar
    public float minX = -5f; // Límites mínimos de posición en X
    public float maxX = 5f; // Límites máximos de posición en X
    public float minY = 0f; // Límites mínimos de posición en Y
    public float maxY = 3f; // Límites máximos de posición en Y

    void Start()
    {
        // Generar la cantidad inicial de objetos
        for (int i = 0; i < cantidadObjetos; i++)
        {
            GenerarObjeto();
        }
    }

    // Método para generar un objeto en una posición aleatoria
    void GenerarObjeto()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 posicion = new Vector3(randomX, randomY, 0f);
        Instantiate(objetoPrefab, posicion, Quaternion.identity);
    }

    // Método llamado cuando un objeto es destruido
    public void ObjetoDestruido()
    {
        // Generar un nuevo objeto en una posición aleatoria
        GenerarObjeto();
    }
}
