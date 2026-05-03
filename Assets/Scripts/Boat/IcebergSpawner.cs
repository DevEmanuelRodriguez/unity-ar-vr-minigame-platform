using UnityEngine;

public class IcebergSpawner : MonoBehaviour
{
    public GameObject icebergPrefab; // El prefab que vamos a generar

    public float minX = -2.8f; // Límite izquierdo donde puede aparecer
    public float maxX = 2.8f;  // Límite derecho donde puede aparecer

    public float spawnTime = 1.2f; // Cada cuánto aparece un iceberg

    void Start()
    {
        // Llama repetidamente al método SpawnIceberg
        InvokeRepeating(nameof(SpawnIceberg), 1f, spawnTime);
    }

    void SpawnIceberg()
    {
        // Elegimos una posición aleatoria entre los límites horizontales
        float randomX = Random.Range(minX, maxX);

        // Creamos la posición de aparición
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);

        // Instanciamos un iceberg en esa posición
        Instantiate(icebergPrefab, spawnPosition, Quaternion.identity);
    }
}