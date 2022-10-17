using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    [SerializeField] private GameObject spawn1;
    [SerializeField] private GameObject spawn2;

    // Collision detection
    private void OnCollisionEnter(Collision collision)
    {
        
        // If the bullet hit a target
        if (collision.gameObject.tag == "target")
        {
            // Call the dummie's function to change its state from the spawn platform
            if (!collision.gameObject.GetComponent<changeState>().modifyState())
                spawn1.GetComponent<spawnDummies>().CreateTarget();
            
            // Destroy the bullet
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "targetSphere")
        {
            // Destroy the target
            Destroy(collision.gameObject);
            // Destroy the bullet
            Destroy(gameObject);
            // Create a new target
            spawn2.GetComponent<spawnSpheres>().CreateTargetSphere();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
