using UnityEngine;

public class ObstacleSpawnerAR : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private Transform player;

    public float spawnDistance = 2f;
    public float spawnInterval = 2f;
    public float lateralRange = 0.3f;

    private float timer = 0f;

    void Update()
    {
        if (player == null)
        {
            GameObject foundPlayer = GameObject.FindWithTag("Player");

            if (foundPlayer != null)
            {
                player = foundPlayer.transform;
            }

            return;
        }

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefab == null) return;

        // generar justo delante del player
        Vector3 spawnPos =
            player.position +
            player.forward * spawnDistance;

        Instantiate(
            obstaclePrefab,
            spawnPos,
            Quaternion.LookRotation(-player.forward)
        );
    }
}