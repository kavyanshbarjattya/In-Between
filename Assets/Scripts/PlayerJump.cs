using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerBody;
    [SerializeField] AudioSource _jumpSound;
    public bool _isJump;

    private void Start()
    {
        print(PlayerPrefs.GetInt("Jump"));
        if (PlayerPrefs.GetInt("Jump" , 0) == 0)
        {
            _isJump = false;
        }
        else if(PlayerPrefs.GetInt("Jump") == 1)
        {
            _isJump = true;
        }
    }
    public void Jump()
    {
        if (_isJump)
        {
            _playerBody.gravityScale = -_playerBody.gravityScale;
            if(!_jumpSound.isPlaying )
            {
                _jumpSound.Play();
            }
            // ----------------Play Woosh Sound-------------------
        }
    }
}
