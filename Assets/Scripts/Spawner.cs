using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    private bool hasSpawned = false; // Flag to check if balls have already been spawned

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !hasSpawned)
        {
            SpawnBalls();
            hasSpawned = true; // Set the flag to true after spawning the balls
        }
    }

    private void SpawnBalls()
    {
        for (int i = 0; i < 10; i++)
        {
            // Instantiate a new ball
            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);

           
            Vector3 direction = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            ).normalized;

            // Set the velocity of the ball's Rigidbody to move it in the random direction
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * 10f; // Set speed to 10 units
            }
            else
            {
                Debug.LogError("Ball prefab does not have a Rigidbody component!");
            }
        }
    }
}
