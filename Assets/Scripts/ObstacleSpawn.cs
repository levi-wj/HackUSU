using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject[] encounters;
    public int[] weights;
    public Transform parent;

    private List<int> weightedEncounters = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < encounters.Length; i++)
        {
            for (int j = 0; j < weights[i]; j++)
            {
                weightedEncounters.Add(i);
            }
        }

        Instantiate(encounters[0], transform.position, transform.rotation, parent);
    }

    public void spawnEncounter() {
        int encounterIndex = weightedEncounters[Random.Range(0, weightedEncounters.Count)];
        Instantiate(encounters[encounterIndex], transform.position, transform.rotation, parent);
    }
}
