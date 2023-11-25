using TMPro;
using UnityEngine;

public class BestScoreGameOver : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    
    // Start is called before the first frame update
    void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _textMeshProUGUI.text=ScoreManager.Instance.BestScore.ToString();
    }
}
