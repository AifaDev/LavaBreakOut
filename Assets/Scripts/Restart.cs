using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //reload the current active scene after 0.5s
            Invoke("RestartScene", 0.5f);
        }
    }

    void RestartScene()
    {
        // Get the name of the current active scene
        string currentSceneName = SceneManager.GetActiveScene().name;
        // Reload the current active scene
        SceneManager.LoadScene(currentSceneName);
    }
}
