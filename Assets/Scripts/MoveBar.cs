using UnityEngine;

public class MoveBar : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float leftLimit = -8f;
    [SerializeField] private float rightLimit = 8f;
    private Rigidbody rb;
    private float halfWidth;

    void Start()
    {
        InitializePaddle();
    }

    private void InitializePaddle()
    {
        rb = GetComponent<Rigidbody>();
        halfWidth = GetComponent<BoxCollider>().size.x / 2;
        // Optionally, you can remove the Debug.Log line after confirming the values are correct
        Debug.Log($"Half Width: {halfWidth}, Left Limit: {leftLimit}, Right Limit: {rightLimit}");
    }

    private void FixedUpdate()
    {
        HandlePaddleMovement();
    }

    private void HandlePaddleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 newPosition = transform.position + direction * Time.deltaTime * speed;
        AdjustPaddlePosition(ref newPosition);
        rb.MovePosition(newPosition);
    }

    private void AdjustPaddlePosition(ref Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, leftLimit + halfWidth, rightLimit - halfWidth);
    }
}
