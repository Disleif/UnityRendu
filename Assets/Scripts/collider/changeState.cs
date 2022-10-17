using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeState : MonoBehaviour
{
    // Set hp to 2
    private bool hp = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool modifyState()
    {
        if (hp == true){
            // Change the color of the target to red
            GetComponent<MeshRenderer>().material.SetColor("_color1", Color.red);
            GetComponent<MeshRenderer>().material.SetColor("_color2", Color.yellow);

            // Change health state
            hp = false;

            // Return "still alive"
            return true;
        }
        else {
            // Destroy the target
            Destroy(gameObject);
            
            // Return "dead"
            return false;
        }
    }
}
