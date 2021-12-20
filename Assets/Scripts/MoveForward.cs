using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Makes the animals move forward
public class MoveForward : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
