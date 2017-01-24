using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log("LoadLevel requested for: " + name);
        SceneManager.LoadScene(name);
        Brick.breakableBrickCount = 0;
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableBrickCount <= 0)
        {
            LoadNextLevel();
        }
    }

    internal void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Brick.breakableBrickCount = 0;
    }
}
