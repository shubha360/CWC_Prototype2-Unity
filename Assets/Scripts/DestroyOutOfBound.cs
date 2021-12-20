using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    private float leftBound = -30;
    private float rightBound = 30;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound || 
            transform.position.z < lowerBound || 
            transform.position.x < leftBound ||
            transform.position.x > rightBound)
        {
            gameManager.addLives(-1);
            Destroy(gameObject);
        }
    }
}
