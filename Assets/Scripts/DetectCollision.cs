using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.lives <= 0)
        {
            Debug.Log("Game Over.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.name == "Player")
        {
            PlayerController.lives--;

            if (PlayerController.lives > 0)
            {
                Debug.Log("Score: " + PlayerController.score + ", Lives: " + PlayerController.lives);
            }

        } else
        {

            if (gameObject.name.StartsWith("Food"))
            {
                PlayerController.score++;
            }

            if (PlayerController.lives > 0)
            {
                Debug.Log("Score: " + PlayerController.score + ", Lives: " + PlayerController.lives);
            }


            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
