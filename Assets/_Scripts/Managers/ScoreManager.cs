using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public float GameScore { get; private set; }
    public float BestScore { get; private set; }
    
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
    }

    public void AddScore()
    {
        GameScore++;
        
        if (GameScore > BestScore)
        {
            BestScore = GameScore;
        }
        
        EventManager.Instance.ChangeScoreGame();
    }

    public void ResetScore()
    {
        GameScore = 0;
    }
    
}
