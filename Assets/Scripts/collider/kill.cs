using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    [SerializeField] private GameObject init;

    // Collision detection
    private void OnCollisionEnter(Collision collision)
    {
        // If the bullet hit a target
        if (collision.gameObject.tag == "target")
        {
            // Destroy the target
            Destroy(collision.gameObject);
            // Create a new target
            init.GetComponent<hitregisterer>().CreateTarget();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
