using UnityEngine;

public class MoveBall : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private float speed = 10f;
    [SerializeField] private AudioClip bombClip; // Audio clip for Bomb
    [SerializeField] private AudioClip wallClip; // Audio clip for Wall
    [SerializeField] private AudioClip targetClip; // Audio clip for Target

    private Rigidbody rb;
    private Transform myTransform;
    private AudioSource audioSource; // Single audio source component

    void Start()
    {
        myTransform = transform;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        SetInitialVelocity(new Vector3(0, -1, 0));
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
    }

    private void SetInitialVelocity(Vector3 initialVelocity)
    {
        rb.velocity = initialVelocity.normalized * speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        Vector3 direction = rb.velocity.normalized;
        switch (other.gameObject.tag)
        {
            case "Player":
                float difference = myTransform.position.x - other.transform.position.x;
                direction.x += difference * 0.5f;
                AdjustDirection(direction.normalized);
                PlaySound(wallClip); // Play Wall sound
                break;
            case "Bomb":
                HandleBombCollision(other, direction);
                PlaySound(bombClip); // Play Bomb sound
                break;
            case "Ground":
                Destroy(gameObject);
                break;
            case "Target":
                Destroy(other.gameObject);
                speed += 0.5f;
                PlaySound(targetClip); // Play Target sound
                break;
            case "Wall":
                direction.y += 0.1f;
                AdjustDirection(direction.normalized);
                PlaySound(wallClip); // Play Wall sound
                break;
        }
    }

    private void HandleBombCollision(Collision other, Vector3 direction)
    {
        Destroy(other.gameObject, 0.1f);
        Instantiate(explosionParticle, other.transform.position, explosionParticle.transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(other.transform.position, 1.9f);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Target"))
            {
                Destroy(collider.gameObject, 0.1f);
            }
        }
    }

    private void AdjustDirection(Vector3 direction)
    {
        if (Mathf.Abs(direction.y) < 0.3f)
            direction.y = direction.y < 0 ? -0.3f : 0.3f;
        if (Mathf.Abs(direction.x) < 0.2f)
            direction.x = direction.x < 0 ? -0.2f : 0.2f;
        rb.velocity = direction.normalized * speed;
    }


private void PlaySound(AudioClip clip)
{

    audioSource.PlayOneShot(clip);
}

}
