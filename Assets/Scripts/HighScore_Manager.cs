using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore_Manager : MonoBehaviour
{
    [SerializeField] Score_Manager _scoreManager;
    [SerializeField] TextMeshProUGUI _highscoreTxt;


    private void Start()
    {
        print(PlayerPrefs.GetFloat("HighScore"));
        _highscoreTxt.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }
    public void HighScore()
    {
        if (_scoreManager._score > PlayerPrefs.GetFloat("HighScore"))
        {
            _scoreManager._highScore = _scoreManager._score;
            PlayerPrefs.SetFloat("HighScore", _scoreManager._highScore);
            PlayerPrefs.Save();
            _highscoreTxt.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore").ToString();
        }
    }
}
