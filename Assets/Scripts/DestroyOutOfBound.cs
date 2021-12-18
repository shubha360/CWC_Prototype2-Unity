using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    private float leftBound = -30;
    private float rightBound = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound || 
            transform.position.z < lowerBound || 
            transform.position.x < leftBound ||
            transform.position.x > rightBound)
        {   

            if (gameObject.name.StartsWith("Food"))
            {
                PlayerController.lives--;
                Debug.Log("Score: " + PlayerController.score + ", Lives: " + PlayerController.lives);
            }

            Destroy(gameObject);
        }
    }
}
