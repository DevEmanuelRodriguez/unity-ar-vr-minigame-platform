using UnityEngine;

public class VRSpawner : MonoBehaviour
{
    public GameObject targetPrefab;

    public float spawnDistance = 12f;
    public float spawnInterval = 2f;

    public Transform playerCamera;

    [Header("Scale Random")]
    public float minScale = 0.6f;
    public float maxScale = 1.8f;

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
        if (playerCamera == null)
            return;

        Vector3 spawnPosition =
            playerCamera.position +
            playerCamera.forward *
            spawnDistance;

        // izquierda / derecha
        spawnPosition +=
            playerCamera.right *
            Random.Range(-1.5f, 1.5f);

        // arriba / abajo
        spawnPosition +=
            playerCamera.up *
            Random.Range(-0.2f, 1f);

        // evitar debajo de la tierra
        spawnPosition.y =
            Mathf.Max(
                spawnPosition.y,
                0.5f
            );

        GameObject newTarget =
            Instantiate(
                targetPrefab,
                spawnPosition,
                Quaternion.identity
            );

        // escala aleatoria
        float randomScale =
            Random.Range(
                minScale,
                maxScale
            );

        newTarget.transform.localScale =
            Vector3.one *
            randomScale;
    }
}