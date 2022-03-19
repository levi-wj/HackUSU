using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float moveSpeed = 1;
    public int score = 0;
    private Text text = null;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= .2f) {
            moveSpeed += .2f;
            timer = 0f;
            ChangeScore(1);
        }

        text.text = "Score: " + score.ToString();
    }

    public void ChangeScore(int amount)
    {
        score += amount;
    }
}
