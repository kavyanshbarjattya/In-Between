using UnityEngine;

public class GameInputHandler : MonoBehaviour
{
    [SerializeField] private PlayerJump blackPlayer;
    [SerializeField] private PlayerJump whitePlayer;

    public void OnJumpButtonPressed()
    {
        blackPlayer.Jump();
        whitePlayer.Jump();
    }
}
