using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameSpeedState
    {
        Pause,
        Normal,
        Turbo
    }

    public enum GameState
    {
        Wait,
        Game,
        GameOver
    }

    public GameSpeedState GameSpeed;
    public GameState Game;
    public Transform EnemyGroup;
    public GameObject GameOverUI;
    public GameObject ScoreUI;
    public GameObject StartUI;
    public GameObject RespawnSystem;
    [SerializeField] private TextMeshProUGUI warningText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        GameSpeed = GameSpeedState.Normal;
        Game = GameState.Wait;
    }

    public void ChangeGameSpeed(GameSpeedState carSpeedState)
    {
        GameSpeed = carSpeedState;
        EventManager.Instance.ChangeGameSpeed();
    }

    public void ChangeGameState(GameState gameState)
    {
        Game = gameState;
        if (gameState == GameState.GameOver)
        {
            ScoreUI.SetActive(false);
            GameOverUI.SetActive(true);
        }
    }

    public void StartNewGame()
    {
        ScoreManager.Instance.ResetScore();
        foreach (Transform child in EnemyGroup) Destroy(child.gameObject);
        GameOverUI.SetActive(false);
        StartUI.SetActive(true);
        GameSpeed = GameSpeedState.Normal;
        EventManager.Instance.ChangeGameSpeed();
    }

    public void RestartGame()
    {
        ScoreManager.Instance.ResetScore();
        foreach (Transform child in EnemyGroup) Destroy(child.gameObject);
        GameOverUI.SetActive(false);
        ScoreUI.SetActive(true);
        GameSpeed = GameSpeedState.Normal;
        RespawnSystem.SetActive(true);
        EventManager.Instance.ChangeGameSpeed();
        ChangeGameState(GameState.Game);
    }


    private float timeToChangeGameSpeed = 10;
    private float cyrTimeToChangeGameSpeed = 10;

    private void Update()
    {
        if (Game == GameState.Game)
        {
            cyrTimeToChangeGameSpeed -= Time.deltaTime;

            if (cyrTimeToChangeGameSpeed <= 5)
            {
                warningText.text = GameSpeed == GameSpeedState.Turbo
                    ? "Ускорение закончится через " + $"{cyrTimeToChangeGameSpeed:F0}"
                    : "Ускорение через " + $"{cyrTimeToChangeGameSpeed:F0}";
            }

            if (cyrTimeToChangeGameSpeed <= 0)
            {
                warningText.text = "";
                if (GameSpeed == GameSpeedState.Turbo)
                {
                    ChangeGameSpeed(GameSpeedState.Normal);
                }
                else
                {
                    ChangeGameSpeed(GameSpeedState.Turbo);
                }

                cyrTimeToChangeGameSpeed = timeToChangeGameSpeed;
            }
        }
    }
}
