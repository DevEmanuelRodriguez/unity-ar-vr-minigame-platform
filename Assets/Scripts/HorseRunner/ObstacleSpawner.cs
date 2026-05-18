using UnityEngine;

// Crea obstáculos random
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public float minSpawnTime = 1.5f;
    public float maxSpawnTime = 3f;

    [Header("Random Scale")]
    public float minScale = 0.8f;
    public float maxScale = 1.4f;

    void Start()
    {
        SpawnAgain();
    }

    void SpawnAgain()
    {
        float delay =
            Random.Range(
                minSpawnTime,
                maxSpawnTime
            );

        Invoke(
            nameof(SpawnObstacle),
            delay
        );
    }

    void SpawnObstacle()
    {
        GameObject obstacle =
            Instantiate(
                obstaclePrefab,
                transform.position,
                Quaternion.identity
            );

        // Escala aleatoria
        float randomScale =
            Random.Range(
                minScale,
                maxScale
            );

        obstacle.transform.localScale =
            Vector3.one * randomScale;

        SpawnAgain();
    }
}