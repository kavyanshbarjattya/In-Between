using UnityEngine;
using UnityEngine.Rendering;

public class GameOver_Manager : MonoBehaviour
{
    [SerializeField] HighScore_Manager _highscore_manager;
    [SerializeField] GameObject _restartBtn;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _highscore_manager.HighScore();
            _restartBtn.SetActive(true);
            Game_Manager.instance.MusicPitch();
            Game_Manager.instance.ScreenColor();
            Time.timeScale = 0;
        }
    }
}
