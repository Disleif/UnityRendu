using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDummies : MonoBehaviour
{
    private List<GameObject> dummies = new List<GameObject>();
    [SerializeField] public GameObject target;
    [SerializeField, Range(1,5)] private int targetNumber = 5;
    private int lastTargetNumber;
    // Start is called before the first frame update
    void Start()
    {
        lastTargetNumber = targetNumber;

        // Generate targetNumber differente random coordinates between 5 and 20, then -10 and 10
        for (int i = 0; i < targetNumber; i++)
        {
            CreateTarget();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Adapt the numer of dummies to the targetNumber
        if (lastTargetNumber < targetNumber) {
            for (int i = lastTargetNumber; i < targetNumber; i++) {
                CreateTarget();
            }
            lastTargetNumber = targetNumber;
        }
        else if (lastTargetNumber > targetNumber) {
            for (int i = lastTargetNumber; i > targetNumber; i--) {
                // Remove the last object in the list
                Destroy(dummies[dummies.Count - 1]);
                dummies.RemoveAt(dummies.Count - 1);
            }
            lastTargetNumber = targetNumber;
        }
    }

    public void CreateTarget() {
        // Generate random coordinates
        float x = Random.Range(-8, 12);
        float z = Random.Range(10, 20);
        // Checks if there is any object in the coordinates
        // 0.5 to avoid the size of the object making it clip, +0.01 because the spawn platform is 0.01 higher than the ground
        while (Physics.CheckSphere(new Vector3(x, 2, z), 0.4f)){
            x = Random.Range(-8, 12);
            z = Random.Range(10, 20);
        };

        // Instantiate a target object in front of main camera, on the cube under the parent object
        GameObject go = Instantiate(target, new Vector3(x, 1, z), Quaternion.identity);
        // Add it to the list
        dummies.Add(go);
    }
}
