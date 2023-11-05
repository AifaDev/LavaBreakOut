using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject targets;
    [SerializeField] private GameObject winText;

    // Update is called once per frame
    void Update()
    {
        CheckTargets();
    }

    private void CheckTargets()
    {
        if(targets.transform.childCount == 0)
        {
            string currentSceneName = SceneManager.GetActiveScene().name; // Get the name of the current active scene

            // Use a switch statement or if conditions to load the appropriate next scene
            switch(currentSceneName)
            {
                case "Level1":
                    SceneManager.LoadScene("Level2");
                    break;
                case "Level2":
                    SceneManager.LoadScene("Level3");
                    break;
                case "Level3":
                    winText.SetActive(true);
                    break;
                default:
                    Debug.LogError("Unexpected scene name: " + currentSceneName);
                    break;
            }
        }
    }
}
