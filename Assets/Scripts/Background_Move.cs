using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Move : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Renderer _renderer;
    void Update()
    {
        _renderer.material.mainTextureOffset += new Vector2(_speed * Time.deltaTime, 0);
    }
}
