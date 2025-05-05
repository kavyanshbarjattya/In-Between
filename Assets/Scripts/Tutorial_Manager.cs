using System.Collections;
using UnityEngine;

public class Tutorial_Manager : MonoBehaviour
{
    [SerializeField] GameObject[] _tutorialUI;
    [SerializeField] PlayerJump[] _playerJump;
    [SerializeField]
    bool _isActive;

    int _currentIndex = 0;
    private void Start()
    {
        foreach (GameObject g in _tutorialUI)
        {
            g.SetActive(false);
        }
    }

    public void NextTutorial()
    {
        if (_currentIndex < _tutorialUI.Length && !_isActive)
        {
            _tutorialUI[_currentIndex].SetActive(true);
            _isActive = true;
            _currentIndex++;
        }
    }

    public void TimeReset()
    {
        Time.timeScale = 1;
        _tutorialUI[_currentIndex - 1].SetActive(false);
        foreach (PlayerJump pj in _playerJump)
        {
            if(pj != null)
            {
                pj.GetComponent<PlayerJump>()._isJump = true;
                pj.GetComponent<PlayerJump>().Jump();
                PlayerPrefs.SetInt("Jump", 1);
                PlayerPrefs.Save();
            }
        }
        _isActive = false;

        if(_currentIndex >= _tutorialUI.Length)
        {
            StartCoroutine(Game_Manager.instance.TimerToStartGame());
            
        }
    }
}
