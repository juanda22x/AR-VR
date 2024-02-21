using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float speed = 0.1f; // Velocidad de movimiento de la serpiente
    private Vector3 direction = Vector3.right; // Direcci�n inicial de la serpiente

    void Update()
    {
        // Mover la serpiente en la direcci�n actual
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void MoveUp()
    {
        if (direction != -Vector3.up) // Evitar que la serpiente retroceda sobre s� misma
            direction = Vector3.up;
    }

    public void MoveDown()
    {
        if (direction != Vector3.up) // Evitar que la serpiente retroceda sobre s� misma
            direction = -Vector3.up;
    }

    public void MoveRight()
    {
        if (direction != -Vector3.right) // Evitar que la serpiente retroceda sobre s� misma
            direction = Vector3.right;
    }

    public void MoveLeft()
    {
        if (direction != Vector3.right) // Evitar que la serpiente retroceda sobre s� misma
            direction = -Vector3.right;
    }
}


