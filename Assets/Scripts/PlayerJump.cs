using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerBody;
    

    public void Jump()
    { 
        _playerBody.gravityScale = -_playerBody.gravityScale;
    }
}
