using UnityEngine;

[RequireComponent(typeof(SpeedData))]
public class MoveToTarget : MonoBehaviour
{
    public Transform cyrTarget;
    public Transform[] targets;
    private int cyrTargetInt = 1;
    private SpeedData _speedData;
    
    private void Start()
    {
        _speedData = GetComponent<SpeedData>();
        cyrTarget = targets[cyrTargetInt];
    }

    private void Update()
    {
        if (_speedData.speed > 0)
        {
            if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
            {
                if (cyrTargetInt != 0)
                {
                    cyrTargetInt--;
                    cyrTarget = targets[cyrTargetInt];
                }
            }

            if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
            {
                if (cyrTargetInt != 3)
                {
                    cyrTargetInt++;
                    cyrTarget = targets[cyrTargetInt];
                }
            }
            
            Vector2 vector2 = (cyrTarget.position - transform.position).normalized;
            var step = _speedData.speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, cyrTarget.position, step);
        }

    }

}
