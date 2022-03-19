using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int moveMin = 2250;
    [SerializeField] private int maxRead = 4000;
    [SerializeField] private int centerGap = 200;
    [SerializeField] private GameObject deathUI = null;

    private LevelManager levelManager = null;
    private ScoreManager scoreManager = null;

    private Vector3[] positions = {
        new Vector3(-2, 1, 0),
        new Vector3(0, 1, 0),
        new Vector3(2, 1, 0)
    };
    private byte targetPos = 1;

    private byte leftIter = 0;
    private int[] leftDist = { 0, 0, 0, 0 };
    private byte rightIter = 0;
    private int[] rightDist = { 0, 0, 0, 0 };
    private bool usingArduino = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        transform.position = positions[targetPos];
    }

    void Update() {
        // alternate controls (no arduino)
        if (!usingArduino) {
            float horizontalInput = Input.GetAxis("Horizontal");
            if      (horizontalInput == 0)  targetPos = 1;
            else if (horizontalInput < 0)   targetPos = 0;
            else if (horizontalInput > 0)   targetPos = 2;
        }

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
        if (leftDistAvg == maxRead - centerGap && rightDistAvg == maxRead - centerGap) {
            targetPos = 1;
        }

        Debug.Log("leftDistAvg: " + leftDistAvg + " rightDistAvg: " + rightDistAvg + " diff: " + diff);
    }

    void MessageArrLeft(string msg)
    {
        usingArduino = true;
        // Debug.Log("MessageArrLeft: " + msg);   
        int num = int.Parse(msg);
        if (num > maxRead) { num = maxRead; }
        if (num < 425) { levelManager.LoadLevel("MainScene"); }

        leftDist[leftIter] = num;
        leftIter = (byte)((leftIter + 1) % 4);
        updatePosition();
    }

    void MessageArrRight(string msg)
    {
        usingArduino = true;
        // Debug.Log("MessageArrRight: " + msg);
        int num = int.Parse(msg);
        if (num > maxRead) { num = maxRead; }
        if (num < 425) { levelManager.LoadLevel("Menu"); }

        rightDist[rightIter] = num;
        rightIter = (byte)((rightIter + 1) % 4);
        updatePosition();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle") {
            Debug.Log("You frickin died you frickin nerd");
            deathUI.active = true;
            scoreManager.StopGame();
        }
    }
}
