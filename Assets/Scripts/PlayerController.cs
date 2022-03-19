using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int moveMin = 2250;
    [SerializeField] private int maxRead = 4000;

    private Vector3[] positions = {
        new Vector3(-2, 1, 0),
        new Vector3(0, 1, 0),
        new Vector3(2, 1, 0)
    };
    private byte targetPos = 1;

    private byte leftIter = 0;
    private int[] leftDist = { 0, 0, 0, 0, 0 };
    private byte rightIter = 0;
    private int[] rightDist = { 0, 0, 0, 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        transform.position = positions[targetPos];
    }

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, positions[targetPos], 6 * Time.deltaTime);
    }

    int getAvg(int[] arr) {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++) {
            sum += arr[i];
        }
        return sum / arr.Length;
    }

    void updatePosition() {
        int leftDistAvg = getAvg(leftDist);
        int rightDistAvg = getAvg(rightDist);
        int diff = leftDistAvg - rightDistAvg;

        targetPos = 1;
        if (diff < -moveMin) {
            targetPos = 0;
        } else if (diff > moveMin) {
            targetPos = 2;
        }

        Debug.Log("leftDistAvg: " + leftDistAvg + " rightDistAvg: " + rightDistAvg + " diff: " + diff);

        // alternate controls (no arduino)
        float horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log(horizontalInput);
        if      (horizontalInput == 0)  targetPos = 1;
        else if (horizontalInput < 0)   targetPos = 0;
        else if (horizontalInput > 0)   targetPos = 2;
    }

    void MessageArrLeft(string msg)
    {
        // Debug.Log("MessageArrLeft: " + msg);   
        int num = int.Parse(msg);
        if (num > maxRead) { num = maxRead; }

        leftDist[leftIter] = num;
        leftIter = (byte)((leftIter + 1) % 5);
        updatePosition();
    }

    void MessageArrRight(string msg)
    {
        // Debug.Log("MessageArrRight: " + msg);
        int num = int.Parse(msg);
        if (num > maxRead) { num = maxRead; }

        rightDist[rightIter] = num;
        rightIter = (byte)((rightIter + 1) % 5);
        updatePosition();
    }
}
