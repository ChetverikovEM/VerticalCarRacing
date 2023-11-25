using UnityEngine;

[RequireComponent(typeof(SpeedData))]
public class Move : MonoBehaviour
{
    private SpeedData _speedData;

    private void Start()
    {
        _speedData = GetComponent<SpeedData>();
    }
    
    private void Update()
    {
        transform.position += Vector3.down * (Time.deltaTime * _speedData.speed);
    }
}
