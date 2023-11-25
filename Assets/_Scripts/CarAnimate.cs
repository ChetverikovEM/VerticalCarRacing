using UnityEngine;

[RequireComponent(typeof(SpeedData))]
public class CarAnimate : MonoBehaviour
{
    private float old_x = 0;
    private SpeedData _speedData;
    
    // Start is called before the first frame update
    void Start()
    {
        _speedData = GetComponent<SpeedData>();
        old_x = transform.position.x;
    }

    void FixedUpdate()
    {
        if (_speedData.speed > 0)
        {
            float rez = old_x - transform.position.x;
            if (rez >= -0.01 && rez <= 0.01)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (rez > 0.01)
            {
                transform.rotation = Quaternion.Euler(0, 0, 25);
            }

            if (rez < -0.01)
            {
                transform.rotation = Quaternion.Euler(0, 0, -25);
            }

            old_x = transform.position.x;
        }
    }
}
