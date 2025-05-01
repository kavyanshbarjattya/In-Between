using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Manager : MonoBehaviour
{
    [SerializeField] GameObject[] _tutorials;
    [SerializeField] PlayerJump[] _jump; 
    int i;
    bool _timeOff;
    void Start()
    {
        for (int i = 0; i < _tutorials.Length; i++)
        {
            _tutorials[i].gameObject.SetActive(false);
        }

    }
    public void Tutorials()
    {
        for (i = 0; i < _tutorials.Length;)
        {
            _tutorials[i].gameObject.SetActive(true);
            i++;
            Time.timeScale = 0;
            _timeOff = true;
            print(i);

        }
    }


    public void TimeReset()
    {
        if( _timeOff)
        {
            Time.timeScale = 1;
            _tutorials[i - 1].gameObject.SetActive(false);
            print(i);
            _timeOff = false;
            print(_timeOff);
        }
    }
}
