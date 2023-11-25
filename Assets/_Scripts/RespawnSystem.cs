using UnityEngine;
using Random = UnityEngine.Random;

public class RespawnSystem : MonoBehaviour
{
    public Transform[] spawnPoints;
    
    [SerializeField] private float defaultTimeToNextSpawnCar;
    [SerializeField] private GameObject enemyGO;
    
    private bool isGameStopped = false;
    private float timeToNextSpawnCar;
    
    private float cyrTimeVolna;
    void Start()
    {
        timeToNextSpawnCar = defaultTimeToNextSpawnCar; 
        cyrTimeVolna = timeToNextSpawnCar;
    }
    private void OnEnable()
    {
        timeToNextSpawnCar = defaultTimeToNextSpawnCar;        
        EventManager.ChangeGameSpeedEvent += ChangeGameSpeed; 
    }

    private void OnDisable()
    {
        EventManager.ChangeGameSpeedEvent -= ChangeGameSpeed; 
    }

    private void ChangeGameSpeed()
    {
        switch (GameManager.Instance.GameSpeed)
        {
            case GameManager.GameSpeedState.Pause:
                gameObject.SetActive(false);
                //isGameStopped = true;
                break;
            case GameManager.GameSpeedState.Turbo:
                timeToNextSpawnCar = defaultTimeToNextSpawnCar / 2;
                //isGameStopped = false;
                break;
            case GameManager.GameSpeedState.Normal:
                timeToNextSpawnCar = defaultTimeToNextSpawnCar;
                //isGameStopped = false;
                break;
            default: 
                break;
        }
    }

    void Update()
    {
        if (!isGameStopped)
        {
            cyrTimeVolna -= Time.deltaTime;

            if (cyrTimeVolna <= 0)
            {
                var cyrTransform = spawnPoints[Random.Range(0, 4)];

                var enemy = Instantiate(enemyGO, cyrTransform.position, cyrTransform.rotation);
                enemy.transform.SetParent(GameManager.Instance.EnemyGroup);

                ScoreManager.Instance.AddScore();
                
                cyrTimeVolna = timeToNextSpawnCar;
            }
        }
    }
}
