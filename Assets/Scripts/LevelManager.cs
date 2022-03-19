using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Quit() {
        Application.Quit();
        Debug.Log("Quit");
    }

    void MessageArrLeft(string msg)
    {
        int num = int.Parse(msg);
        if (num < 500) { LoadLevel("MainScene"); }
    }

    void MessageArrRight(string msg)
    {
        int num = int.Parse(msg);
        if (num < 500) { Quit(); }
    }
}
