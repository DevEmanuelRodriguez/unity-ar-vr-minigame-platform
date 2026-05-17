using UnityEngine;

public class VRSpawner : MonoBehaviour
{
    public GameObject targetPrefab;

    public float spawnDistance = 12f;
    public float spawnInterval = 2f;

    private float timer;

    void Start()
    {
        SpawnTarget();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnTarget();
            timer = 0f;
        }
    }

    void SpawnTarget()
    {
        float randomX = Random.Range(-3f, 3f);
        float randomY = Random.Range(0f, 2.5f);

        Vector3 spawnPosition =
            new Vector3(randomX, randomY, spawnDistance);

        Instantiate(
            targetPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}