using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    public float _score;
    public float _highScore;
    [SerializeField] TextMeshProUGUI _scoreTxt;
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            _score++;
            _scoreTxt.text = "Score: " + _score;
        }
        else
        {
            return;
        }
    }
}
