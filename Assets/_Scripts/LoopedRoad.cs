using UnityEngine;

[RequireComponent(typeof(SpeedData))]
public class LoopedRoad : MonoBehaviour
{
    private float offset;
    private Material mat;
    private SpeedData speedData;
    
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        speedData = GetComponent<SpeedData>();
    }
    
    private void Update()
    {
        offset -= (Time.deltaTime * speedData.speed);
        mat.SetTextureOffset("_MainTex", new Vector2(0,offset ));
    }
   
}
