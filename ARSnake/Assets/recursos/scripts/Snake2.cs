using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake2 : MonoBehaviour
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

    // UI Buttons
    public Button leftButton;
    public Button rightButton;

    private bool isTurningLeft = false;
    private bool isTurningRight = false;

    // Start is called before the first frame update
    void Start()
    {
        //create 5 body first
        GrowSnake();
        

        // Assign button click events
        leftButton.onClick.AddListener(TurnLeft);
        rightButton.onClick.AddListener(TurnRight);
    }

    // Update is called once per frame
    void Update()
    {
        // Move forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // Turn left or right
        if (isTurningLeft)
        {
            transform.Rotate(Vector3.up * -1 * SteerSpeed * Time.deltaTime);
        }
        else if (isTurningRight)
        {
            transform.Rotate(Vector3.up * SteerSpeed * Time.deltaTime);
        }

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

    private void GrowSnake()
    {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            GrowSnake();
            Vector3 randomPosition = new Vector3(Random.Range(-2.0f, 2.0f), 0f, Random.Range(-2.0f, 2.0f));
            Instantiate(enemy, randomPosition, Quaternion.identity);
        }
    }

    // Button click events
    private void TurnLeft()
    {
        isTurningLeft = true;
        isTurningRight = false;
    }

    private void TurnRight()
    {
        isTurningLeft = false;
        isTurningRight = true;
    }
}