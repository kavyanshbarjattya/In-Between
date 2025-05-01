using UnityEngine;

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
            print("Game Over");
            Time.timeScale = 0;
        }
    }
}
