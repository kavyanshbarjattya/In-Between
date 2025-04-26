using UnityEngine;

public class GameInputHandler : MonoBehaviour
{
    [SerializeField] private PlayerGravityController blackPlayer;
    [SerializeField] private PlayerGravityController whitePlayer;

    public void OnJumpButtonPressed()
    {
        blackPlayer.GravityShift();
        whitePlayer.GravityShift();
    }
}
