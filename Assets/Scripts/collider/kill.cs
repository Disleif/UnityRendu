using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    [SerializeField] private GameObject spawn1;
    [SerializeField] private GameObject spawn2;

    // Collision detection
    private void OnCollisionEnter(Collision collision)
    {
        // If the bullet hit a target
        if (collision.gameObject.tag == "target")
        {
            // Destroy the target
            Destroy(collision.gameObject);
            // Destroy the bullet
            Destroy(gameObject);
            // Create a new target
            spawn1.GetComponent<hitregisterer>().CreateTarget();
        }
        else if (collision.gameObject.tag == "targetSphere")
        {
            // Destroy the target
            Destroy(collision.gameObject);
            // Destroy the bullet
            Destroy(gameObject);
            // Create a new target
            spawn2.GetComponent<hitregisterer1>().CreateTargetSphere();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
