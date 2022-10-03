using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitregisterer : MonoBehaviour
{
    private List<GameObject> hitObjects = new List<GameObject>();
    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate a yoru object in front of main camera, on the cube under the parent object
        GameObject go = Instantiate(target, transform.position + new Vector3(0f, -3.9f, 5f), Quaternion.Euler(0, -90, 0));
        // Add it to the list
        hitObjects.Add(go);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
