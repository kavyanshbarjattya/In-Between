using UnityEngine;

public class PlayerGravityController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D playerBody;
    [SerializeField] private Animator playerAnimator; // <-- NEW

    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 360f; // Degrees per second
    [SerializeField] private bool isStartingUpsideDown; // true for white player

    private bool isRotating = false;
    private float targetZRotation;

    void Start()
    {
        if (isStartingUpsideDown)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            playerBody.gravityScale = -Mathf.Abs(playerBody.gravityScale);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerBody.gravityScale = Mathf.Abs(playerBody.gravityScale);
        }
    }

    void Update()
    {
        if (isRotating)
        {
            float currentZ = transform.rotation.eulerAngles.z;
            float newZ = Mathf.MoveTowardsAngle(currentZ, targetZRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newZ);

            if (Mathf.Abs(Mathf.DeltaAngle(newZ, targetZRotation)) < 0.1f)
            {
                transform.rotation = Quaternion.Euler(0, 0, targetZRotation);
                isRotating = false;
                playerAnimator.SetBool("isRolling", false); // <-- Stop roll animation
            }
        }
    }

    public void FlipGravity()
    {
        // Flip gravity
        playerBody.gravityScale = -playerBody.gravityScale;

        // Set target rotation
        targetZRotation = (playerBody.gravityScale > 0) ? 0f : 180f;

        // Start rotating
        isRotating = true;

        // Play roll animation
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isRolling", true);
        }
    }
}