using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject respawnSystem;
    [SerializeField] private GameObject ScoreUI;

    public void OnButton()
    {
        gameObject.SetActive(false);
        respawnSystem.SetActive(true);
        ScoreUI.SetActive(true);
        GameManager.Instance.ChangeGameState(GameManager.GameState.Game);
    }
}
