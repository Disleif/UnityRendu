using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Start the immersion
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the parent object around the y axis
        transform.parent.Rotate(0, Input.GetAxis("Mouse X") * 2, 0);

        // Rotate the camera around the x axis
        transform.Rotate(-Input.GetAxis("Mouse Y") * 2, 0, 0);
    }
}
