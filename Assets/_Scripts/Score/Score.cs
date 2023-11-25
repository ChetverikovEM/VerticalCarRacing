using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    
    // Start is called before the first frame update
    void Start()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        EventManager.ChangeScoreEvent += EventAction;
    }

    private void OnDisable()
    {
        EventManager.ChangeScoreEvent -= EventAction;
    }

    private void EventAction()
    {
        _textMeshProUGUI.text = ScoreManager.Instance.GameScore.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
