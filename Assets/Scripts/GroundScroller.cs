using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(moveSpeed);

        // scroll ground +unit per frame
        transform.Translate(new Vector3(0, 0, -moveSpeed * Time.deltaTime));

    }
}
