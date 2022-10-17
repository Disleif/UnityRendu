using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine Shoot
        StartCoroutine(Shoot());
        // Start the couroutine Restart
        StartCoroutine(Restart());
    }

    // Update is called once per frame
    private IEnumerator Shoot()
    {
        // On mouse leftClick press, instantiate a bullet at the position of the parent object
        // and shoot it to the cursor position
        while (true){
            yield return new WaitWhile(() => !Input.GetMouseButton(0));
            // Get the direction of the camera, redirect a bit to the left and shoot the bullet 
            Vector3 direction = transform.forward * 2 + transform.up * 0.025f;
            // Change the bullet orientation to the cursor direction
            Quaternion rotation = Quaternion.LookRotation(direction);
            // Rotate it for 90° to have the bullet pointing to the cursor
            rotation *= Quaternion.Euler(90, 0, 0);
            // Instantiate the bullet
            GameObject go = Instantiate(bullet, transform.position, rotation);
            // Shoot the bullet to the cursor position
            go.GetComponent<Rigidbody>().AddForce((direction * 2500));
            // Destroy the bullet after 3 second
            Destroy(go, 3);
            // Wait for 1/9,25 seconds (Vandal cadence Valorant)
            yield return new WaitForSeconds(1/9.25f);
        }
    }

    // Restart the game when the player press the r key
    private IEnumerator Restart()
    {
        yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.R));
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
