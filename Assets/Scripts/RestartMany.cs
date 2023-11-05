using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class RestartMany : MonoBehaviour
{
        [SerializeField] private GameObject targets;

    // Function to count the objects with the "Player" tag
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
            // Count all objects with the "Player" tag
            GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Ball");
            // If there are no more objects with the "Player" tag
            if (playerObjects.Length == 1 && targets.transform.childCount != 0)
            {
                // Reload the current active scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        
    }
}
