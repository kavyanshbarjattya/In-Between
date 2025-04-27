using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanesID : MonoBehaviour
{
    [SerializeField] ObjectPool pool;
    enum ID
    {
        Up,
        Down
    }
    [SerializeField] ID lanesId;

    private void Update()
    {
        switch (lanesId)
        {
            case ID.Up:
                break;
            case ID.Down:
                break;
        }
    }
}
