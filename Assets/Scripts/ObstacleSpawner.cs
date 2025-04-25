using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private Transform topLaneSpawnPoint;
    [SerializeField] private Transform bottomLaneSpawnPoint;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float minSpeed = 3f;
    [SerializeField] private float maxSpeed = 7f;
    [SerializeField] private float speedIncreaseRate = 0.05f; // How much speed increases over time
    [SerializeField] private float minSpawnInterval = 0.8f;   // Minimum spawn time limit
    [SerializeField] private float spawnIntervalDecreaseRate = 0.02f; // How fast spawn rate gets quicker

    private float timer;

    private void Awake()
    {
        if (objectPool == null)
        {
            objectPool = FindObjectOfType<ObjectPool>();
            if (objectPool == null)
            {
                Debug.LogError("No ObjectPool found in the scene!");
            }
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnObstacle();
            IncreaseDifficulty();
        }
    }

    private void SpawnObstacle()
    {
        if (objectPool == null) return;

        GameObject obj = objectPool.Get();
        if (obj == null) return;

        bool spawnTop = Random.value > 0.5f;
        obj.transform.position = spawnTop ? topLaneSpawnPoint.position : bottomLaneSpawnPoint.position;
        obj.transform.rotation = Quaternion.identity;

        if (obj.TryGetComponent(out Obstacle obstacle))
        {
            obstacle.SetPool(objectPool);
            obstacle.speed = Random.Range(minSpeed, maxSpeed);
        }

        if (obj.TryGetComponent(out Rigidbody2D rb))
        {
            rb.gravityScale = spawnTop ? -1f : 1f;
            rb.velocity = new Vector2(-obstacle.speed, 0f); // Always move left with obstacle's speed
        }
    }

    private void IncreaseDifficulty()
    {
        // Increase speed range slowly
        minSpeed += speedIncreaseRate * Time.deltaTime;
        maxSpeed += speedIncreaseRate * Time.deltaTime;

        // Decrease spawn interval but clamp it so it never becomes too crazy fast
        spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - spawnIntervalDecreaseRate * Time.deltaTime);
    }
}
