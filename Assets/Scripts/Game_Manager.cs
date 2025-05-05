using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public int _isTutorial;
    [SerializeField] GameObject _taptopStart_Canvas , _uiCanvas , _tutorial;
    [SerializeField] GameObject[] ObjectSpawns , _score;

    public static Game_Manager instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    void Start()
    {
        _taptopStart_Canvas.SetActive(true);
        _uiCanvas.SetActive(false);
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("Tutorial", 0) == 0)
        {
            _tutorial.SetActive(true);
            foreach (GameObject item in ObjectSpawns)
            {
                if (item != null)
                {
                    item.SetActive(false);
                }
            }
            foreach (GameObject s in _score)
            {
                s.SetActive(false);
            }
            return;

        }
        else if(PlayerPrefs.GetInt("Tutorial") == 1)
        {
            _tutorial.SetActive(false);
            foreach (GameObject item in ObjectSpawns)
            {
                if (item != null)
                {
                    item.SetActive(true);
                }
            }

            foreach (GameObject s in _score)
            {
                s.SetActive(true);
            }
        }

    }

    public void TapToPlay()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        _taptopStart_Canvas.SetActive(false);
        _uiCanvas.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadGameScene(int index)
    {
        SceneManager.LoadScene(index);
    }


    public IEnumerator TimerToStartGame()
    {
        yield return new WaitForSeconds(1);
        PlayerPrefs.SetInt("Tutorial", 1);
        PlayerPrefs.Save();
        foreach (GameObject item in ObjectSpawns)
        {
            if (item != null)
            {
                item.SetActive(true);
            }
        }

        foreach (GameObject s in _score)
        {
            s.SetActive(true);
        }
        _tutorial.SetActive(false);

    }

}
