using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    void OnTriggerEnter2D(Collider2D collider)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Lose");
        print("Trigger");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
