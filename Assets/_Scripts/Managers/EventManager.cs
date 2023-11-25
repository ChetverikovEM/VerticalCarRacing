using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    public static Action ChangeGameSpeedEvent;
    public static Action ChangeScoreEvent;
    
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
    
    public void ChangeScoreGame()=>ChangeScoreEvent?.Invoke();
    public void ChangeGameSpeed()=>ChangeGameSpeedEvent?.Invoke();
    
}
