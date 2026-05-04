using UnityEngine;

public class MineSpawnerSub : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject minePrefab;

    [Header("Spawn Timing")]
    [SerializeField] private float spawnRate = 2f;
    private float timer;

    [Header("Spawn Position")]
    [SerializeField] private float spawnX = 10f;

    [Header("Y Settings")]
    [SerializeField] private float minY = -3f;
    [SerializeField] private float maxY = 3f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnMine();
            timer = 0f;
        }
    }

    void SpawnMine()
    {
        float spawnY = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0f);

        Instantiate(minePrefab, spawnPos, Quaternion.identity);
    }
}