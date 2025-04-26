using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerBody;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] Vector3 _setRotation;

    Vector3 _intialRotation;

    private bool isFlipping = false;
    private Quaternion targetRotation;

    private void Start()
    {
        _intialRotation = transform.rotation.eulerAngles;
    }
    void Update()
    {
        if (isFlipping)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.5f)
            {
                transform.rotation = targetRotation;
                isFlipping = false;
            }
        }
    }

    public void Jump()
    {
        if (isFlipping) return; // Prevent double flip while rotating

        // Flip Gravity
        _playerBody.gravityScale = -_playerBody.gravityScale;

        // Set Target Rotation based on new gravity
        if (_playerBody.gravityScale > 0)
        {
            targetRotation = Quaternion.Euler(_intialRotation); // Normal
        }
        else
        {
            targetRotation = Quaternion.Euler(_setRotation); // Upside Down
        }

        isFlipping = true;
    }
}
