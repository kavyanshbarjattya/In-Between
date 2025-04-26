using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore_Manager : MonoBehaviour
{
    [SerializeField] Score_Manager _scoreManager;


    private void Start()
    {
        print(PlayerPrefs.GetFloat("HighScore",0));
    }
    public void HighScore()
    {
        if(_scoreManager._score > PlayerPrefs.GetFloat("HighScore"))
        {
            if (PlayerPrefs.HasKey("HighScore"))
            {
                _scoreManager._highScore = _scoreManager._score;
                PlayerPrefs.SetFloat("HighScore", _scoreManager._highScore);

            }
        }
    }
}
