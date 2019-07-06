using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float speed = 0.1f;
   

    void Start()
    {
        

    }

    
    void Update()
    {
        move();

    }

    private void move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed;
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * speed;
            transform.eulerAngles = new Vector3(0,-180, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.forward * speed;
            transform.eulerAngles = new Vector3(0, 90, 0);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.forward * speed;
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<IInteractable>() != null)
        {
            other.GetComponentInParent<IInteractable>().Interact();
        }
    }

    
}

