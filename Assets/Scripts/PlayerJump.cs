using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerBody;
    public bool _isJump;

    private void Start()
    {
        _isJump = false;
    }


    public void Jump()
    {
        if (_isJump)
        {
            _playerBody.gravityScale = -_playerBody.gravityScale;
        }
    }
}
