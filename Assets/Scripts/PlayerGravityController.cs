using UnityEngine;

public class PlayerGravityController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D playerBody;
    [SerializeField] private Animator playerAnimator; // optional for animation

    [Header("Settings")]
    [SerializeField] private float rotationDuration = 0.2f;
    [SerializeField] private float normalRotationZ = 0f;    // Black Player -> 0
    [SerializeField] private float flippedRotationZ = 180f; // White Player -> 180

    private Quaternion targetRotation;
    private bool isRotating = false;
    private float rotationTimer = 0f;
    private float startRotationZ;

    private void Update()
    {
        if (isRotating)
        {
            rotationTimer += Time.unscaledDeltaTime;
            float t = rotationTimer / rotationDuration;
            float zRotation = Mathf.LerpAngle(startRotationZ, targetRotation.eulerAngles.z, t);
            transform.rotation = Quaternion.Euler(0, 0, zRotation);

            if (t >= 1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }
    }

    public void GravityShift()
    {
        // Flip gravity
        playerBody.gravityScale = -playerBody.gravityScale;

        // Save current rotation
        startRotationZ = transform.rotation.eulerAngles.z;

        // Decide target rotation based on gravity
        if (playerBody.gravityScale > 0)
        {
            targetRotation = Quaternion.Euler(0, 0, normalRotationZ);
        }
        else
        {
            targetRotation = Quaternion.Euler(0, 0, flippedRotationZ);
        }

        rotationTimer = 0f;
        isRotating = true;

        // Optional animation
        if (playerAnimator != null)
            playerAnimator.SetTrigger("Flip");
    }
}
