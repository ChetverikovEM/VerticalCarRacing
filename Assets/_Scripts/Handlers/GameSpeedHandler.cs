using UnityEngine;

[RequireComponent(typeof(SpeedData))]
public class GameSpeedHandler : MonoBehaviour
{
    private const float SpeedMultiplier = 2;
    private SpeedData _speedData;

    private void Start()
    {
        _speedData = GetComponent<SpeedData>();
        EventAction(); 
    }

    private void OnEnable()
    {
        EventManager.ChangeGameSpeedEvent += EventAction;
    }

    private void OnDisable()
    {
        EventManager.ChangeGameSpeedEvent -= EventAction;
    }

    private void EventAction()
    {
        switch (GameManager.Instance.GameSpeed)
        {
            case GameManager.GameSpeedState.Pause:
                _speedData.speed = 0;
                break;
            case GameManager.GameSpeedState.Normal:
                _speedData.speed = _speedData.defaultSpeed;
                break;
            case GameManager.GameSpeedState.Turbo:
                _speedData.speed = _speedData.defaultSpeed*SpeedMultiplier;
                break;
            default: break;
        }
    }
}
