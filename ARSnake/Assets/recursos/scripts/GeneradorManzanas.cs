using UnityEngine;

public class GeneradorManzanas : MonoBehaviour
{
    public GameObject objetoPrefab; // El objeto que quieres generar
    public int cantidadObjetos = 10; // La cantidad de objetos que quieres generar
    public float minX = -5f; // L�mites m�nimos de posici�n en X
    public float maxX = 5f; // L�mites m�ximos de posici�n en X
    public float minY = 0f; // L�mites m�nimos de posici�n en Y
    public float maxY = 3f; // L�mites m�ximos de posici�n en Y

    void Start()
    {
        // Generar la cantidad inicial de objetos
        for (int i = 0; i < cantidadObjetos; i++)
        {
            GenerarObjeto();
        }
    }

    // M�todo para generar un objeto en una posici�n aleatoria
    void GenerarObjeto()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 posicion = new Vector3(randomX, randomY, 0f);
        Instantiate(objetoPrefab, posicion, Quaternion.identity);
    }

    // M�todo llamado cuando un objeto es destruido
    public void ObjetoDestruido()
    {
        // Generar un nuevo objeto en una posici�n aleatoria
        GenerarObjeto();
    }
}
