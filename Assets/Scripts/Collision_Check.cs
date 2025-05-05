using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Check : MonoBehaviour
{
    [SerializeField] Tutorial_Manager _tutorial_manager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            _tutorial_manager.NextTutorial();
        }
    }
}
