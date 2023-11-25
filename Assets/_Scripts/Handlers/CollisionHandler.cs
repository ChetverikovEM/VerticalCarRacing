using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.ChangeGameSpeed(GameManager.GameSpeedState.Pause);
        GameManager.Instance.ChangeGameState(GameManager.GameState.GameOver);
        //EventManager.Instance.StopGame();
    }
}
