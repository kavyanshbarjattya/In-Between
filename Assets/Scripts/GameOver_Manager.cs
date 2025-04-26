using UnityEngine;

public class GameOver_Manager : MonoBehaviour
{
    [SerializeField] HighScore_Manager _highscore_manager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _highscore_manager.HighScore();
            Time.timeScale = 0;
        }
    }
}
