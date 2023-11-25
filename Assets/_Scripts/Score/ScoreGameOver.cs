using TMPro;
using UnityEngine;

public class ScoreGameOver : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    
    // Start is called before the first frame update
    void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _textMeshProUGUI.text=ScoreManager.Instance.GameScore.ToString();
    }

}
