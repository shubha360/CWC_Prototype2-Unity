using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private float speed = 15;
    private float xRange = 15;
    private float zRange = 10;

    public static int score = 0;
    public static int lives = 3;


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

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if (transform.position.z > zRange)
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
