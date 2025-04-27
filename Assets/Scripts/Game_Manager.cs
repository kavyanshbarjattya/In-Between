using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    bool _isTutorial;
    [SerializeField] GameObject _taptopStart_Canvas , _uiCanvas;
    void Start()
    {
        _taptopStart_Canvas.SetActive(true);
        _uiCanvas.SetActive(false);
        Time.timeScale = 0;
    }

    public void TapToPlay()
    {
        /*if(_isTutorial)
        {
            
        }*/
        Time.timeScale = 1;
        _taptopStart_Canvas.SetActive(false);
        _uiCanvas.SetActive(true);

    }
}
