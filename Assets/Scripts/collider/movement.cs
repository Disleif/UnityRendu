using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Move the player according to input taking into account the camera rotation
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        Vector3 direction = forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal");
        // Move the player
        transform.position += direction * Time.deltaTime * 7.5f;

        
        
    }
}
