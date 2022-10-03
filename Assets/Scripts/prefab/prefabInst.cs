using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabInst : MonoBehaviour
{
    [SerializeField, Range(0,50)] private int prefCount = 5;
    private int lastCount, lastRadius;
    [SerializeField, Range(1,10)] private int circleRadius = 5;
    [SerializeField] private GameObject prefab;

    private List<GameObject> prefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        lastCount = prefCount;
        lastRadius = circleRadius;
        // On start, create prefabCount number of prefabs and place them in circle at circleRadius distance around the parent object
        applyPrefabs();
    }

    // Update is called once per frame
    void Update()
    {
        // On editor change for prefCount or circleRadius : the number of prefabs according to prefCount along with the circleRadius
        if (lastCount != prefCount || lastRadius != circleRadius)
        {
            applyPrefabs();
        }
    }

    // NOTE pour prof : J'ai décidé de tout réinstantier systématiquement et m'éviter de devoir gérer les ajouts/suppressions de prefabs
    // en ciblant les objets existants ne manipulant que ceux souhaités. Bon et puis c'est plus sympa les couleurs changent toutes, c'est plus joli :p
    void applyPrefabs(){

        // Destroy the GameObjects in the list
        foreach (GameObject go in prefabs) {
            Destroy(go);
        }

        // Clear the list of prefabs
        prefabs.Clear();

        for (int i = 0; i < prefCount; i++){
            float angle = i * Mathf.PI * 2 / prefCount;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * circleRadius;
            // Assign a random color to the prefab
            Color color = new Color(Random.value, Random.value, Random.value, 1.0f);
            // Instantiate the prefab
            GameObject go = Instantiate(prefab, pos, Quaternion.identity);
            // Set the color of the prefab
            go.GetComponent<Renderer>().material.color = color;

            prefabs.Add(go);
        }
        lastCount = prefCount;
        lastRadius = circleRadius;
    }
}
