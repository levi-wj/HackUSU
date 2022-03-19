using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    public int weight = 1;

    private ObstacleSpawn spawn = null;

    private int destroyZ = -15;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("ObstacleSpawn").GetComponent<ObstacleSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < destroyZ)
        {
            spawn.spawnEncounter();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collision");
        }
    }
}
