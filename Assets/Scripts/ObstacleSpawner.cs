using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Object Pool and Spawn Point")]
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool isTopLane = true; // Is this spawner for Top Lane?

    [Header("Spawn Settings")]
    [SerializeField] private float initialSpawnInterval = 2f;
    [SerializeField] private float minSpawnInterval = 0.8f;
    [SerializeField] private float spawnIntervalDecreaseRate = 0.02f;

    [Header("Obstacle Speed Settings")]
    [SerializeField] private float minSpeed = 3f;
    [SerializeField] private float maxSpeed = 7f;
    [SerializeField] private float speedIncreaseRate = 0.05f;

    [Header("Safe Spawn Settings")]
    [SerializeField] private float safeSpawnGap = 0.5f; // seconds to wait between two lane spawns

    private float timer;
    private float spawnInterval;
    private float currentSpeed;

    // Static shared variable between lanes
    private static float lastSpawnTimeTop = -999f;
    private static float lastSpawnTimeBottom = -999f;

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

        spawnInterval = initialSpawnInterval;
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        timer += deltaTime;

        if (timer >= spawnInterval)
        {
            if (CanSpawnSafely())
            {
                timer = 0f;
                SpawnObstacle();
                IncreaseDifficulty(deltaTime);
            }
        }
    }

    private bool CanSpawnSafely()
    {
        float now = Time.time;

        if (isTopLane)
        {
            if (now - lastSpawnTimeBottom < safeSpawnGap)
                return false;
        }
        else
        {
            if (now - lastSpawnTimeTop < safeSpawnGap)
                return false;
        }

        return true;
    }

    private void SpawnObstacle()
    {
        if (objectPool == null) return;

        GameObject obj = objectPool.Get();
        if (obj == null) return;

        obj.transform.position = spawnPoint.position;

        if (obj.TryGetComponent(out Obstacle obstacle))
        {
            currentSpeed = Random.Range(minSpeed, maxSpeed);
            obstacle.SetPool(objectPool);
            obstacle.speed = currentSpeed;
        }

        if (obj.TryGetComponent(out Rigidbody2D rb))
        {
            rb.gravityScale = isTopLane ? -1f : 1f;
            rb.velocity = new Vector2(-currentSpeed, 0f);
        }

        // Record last spawn time
        if (isTopLane)
            lastSpawnTimeTop = Time.time;
        else
            lastSpawnTimeBottom = Time.time;
    }

    private void IncreaseDifficulty(float deltaTime)
    {
        minSpeed += speedIncreaseRate * deltaTime;
        maxSpeed += speedIncreaseRate * deltaTime;
        spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - spawnIntervalDecreaseRate * deltaTime);
    }

    public float GetCurrentObstacleSpeed()
    {
        return currentSpeed;
    }
}
