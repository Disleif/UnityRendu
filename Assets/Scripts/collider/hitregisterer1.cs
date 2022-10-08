using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitregisterer1 : MonoBehaviour
{
    private List<GameObject> dummies = new List<GameObject>();
    [SerializeField] private GameObject targetSphere;
    [SerializeField, Range(1,10)] private int targetNumber = 5;
    private int lastTargetNumber;
    // Start is called before the first frame update
    void Start()
    {
        lastTargetNumber = targetNumber;

        // Generate targetNumber differente random coordinates between 5 and 20, then -10 and 10
        for (int i = 0; i < targetNumber; i++)
        {
            CreateTargetSphere();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Adapt the numer of dummies to the targetNumber
        if (lastTargetNumber < targetNumber) {
            for (int i = lastTargetNumber; i < targetNumber; i++) {
                CreateTargetSphere();
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

    public void CreateTargetSphere() {
        // Generate random coordinates 
        float x = Random.Range(22.5f, 37.5f);
        float y = Random.Range(1.5f, 7.5f);
        float z = Random.Range(-2.5f, 17.5f);
        // Checks if there is any object in the coordinates
        while (Physics.CheckSphere(new Vector3(x, y, z), 1)){
            x = Random.Range(22.5f, 37.5f);
            y = Random.Range(1.5f, 7.5f);
            z = Random.Range(-2.5f, 17.5f);
        };

        // Instantiate a sphere object
        GameObject go = Instantiate(targetSphere, new Vector3(x, y, z), Quaternion.identity);
        // Add it to the list
        dummies.Add(go);
    }
}
