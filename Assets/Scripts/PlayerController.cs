using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int senseDist = 1750;
    private Vector3[] positions = {
        new Vector3(-2, 1, 0),
        new Vector3(0, 1, 0),
        new Vector3(2, 1, 0)
    };

    private int leftDist = 0;
    private int rightDist = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = positions[1];
    }

    void updatePosition() {
        byte pos = 1;
        if (leftDist < senseDist) { pos -= 1; }
        if (rightDist < senseDist) { pos += 1; }
        transform.position = positions[pos];
    }

    void MessageArrLeft(string msg)
    {
        // Debug.Log("MessageArrLeft: " + msg);   
        leftDist = Int32.Parse(msg);
        updatePosition();
    }

    void MessageArrRight(string msg)
    {
        // Debug.Log("MessageArrRight: " + msg);
        rightDist = Int32.Parse(msg);
        updatePosition();
    }
}
