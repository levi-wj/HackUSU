using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{
    [SerializeField]
    float scale = 200;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Wrap functionality enabled");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            scale * (1.5f - .1f)
        );

        if (transform.position.z < -100f) {
            Debug.Log("Wrapping object");
            transform.position = newPosition;
        }
    }
}
