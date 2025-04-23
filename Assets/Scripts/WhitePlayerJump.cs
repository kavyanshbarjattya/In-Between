using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePlayerJump : MonoBehaviour
{
    [SerializeField] Rigidbody2D _playerBody;
    bool _isJump;
    void Update()
    {
        Jumping();
    }

    void Jumping()
    {
        if (_isJump)
        {
            _playerBody.gravityScale = -_playerBody.gravityScale;
            _isJump = false;
        }
        
    }

    public void Jump()
    {
        if(!_isJump)
        {
            _isJump = true;
        }
        else
        {
            _isJump = false;
        }
    }
}
