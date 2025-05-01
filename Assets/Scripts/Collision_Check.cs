using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Check : MonoBehaviour
{
    [SerializeField] Tutorial_Manager _tutorialManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Tutorial"))
        {
            _tutorialManager.Tutorials();
        }
    }
}
