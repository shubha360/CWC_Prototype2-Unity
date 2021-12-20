using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the player's movement.

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private float speed = 15;
    
    private float xRange = 15; // horizontal range
    private float zRange = 10; // vertival range

    public static int score = 0;
    public static int lives = 3;
    
    // To store the prefab of the food. Steak in this case.
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Score at Start: " + PlayerController.score + ", Lives at Start: " + PlayerController.lives);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (transform.position.x < -xRange) // left side
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange) // right side
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < 0) // top
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if (transform.position.z > zRange) // bottom
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        transform.Translate(Vector3.forward* Time.deltaTime * verticalInput * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 projectilePosition = new Vector3(transform.position.x, 0, transform.position.z);
            Instantiate(projectilePrefab, projectilePosition, projectilePrefab.transform.rotation);
        }
    }
}
