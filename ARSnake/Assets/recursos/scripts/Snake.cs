using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    // Settings
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 10;


    // References
    public GameObject BodyPrefab;
    public GameObject enemy;

    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        //create 5 body first
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
    }

    // Update is called once per frame
    void Update()
    {

        // Move forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // Steer
        float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            GrowSnake();
            //Instantiate(enemy, new Vector3(Random.Range(-1.0f, 1.0f), 0f, 0f), Quaternion.identity);
        }
    }

    private void GrowSnake()
    {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
        // Generar una nueva posición aleatoria
        Vector3 newPosition = GenerateRandomPosition();

        // Instanciar el objeto en la nueva posición
        Instantiate(enemy, newPosition, Quaternion.identity);
    }

    private Vector3 GenerateRandomPosition()
    {
        // Generar coordenadas X y Z aleatorias dentro de ciertos límites
        float newX = Random.Range(-1.0f, 1.0f);
        float newZ = Random.Range(0.0f, -6.0f);

        // Devolver una nueva posición con las coordenadas aleatorias y manteniendo la misma altura
        return new Vector3(newX, 0.20f, newZ);
    }

}
