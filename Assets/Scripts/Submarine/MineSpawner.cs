using UnityEngine;

public class MineSpawnerSub : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject minePrefab;

    [Header("Spawn Timing")]
    [SerializeField]
    private float spawnRate = 2f;

    private float timer;

    [Header("Spawn Position")]
    [SerializeField]
    private float spawnX = 10f;

    [Header("Lane Positions")]
    [SerializeField]
    private float lane1 = 3f;

    [SerializeField]
    private float lane2 = 1f;

    [SerializeField]
    private float lane3 = -1f;

    [SerializeField]
    private float lane4 = -3f;

    private float[] lanes;

    private int lastLane = -1;

    void Start()
    {
        lanes = new float[]
        {
            lane1,
            lane2,
            lane3,
            lane4
        };
    }

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
        int laneIndex;

        // evitar mismo carril consecutivo
        do
        {
            laneIndex =
                Random.Range(
                    0,
                    lanes.Length);
        }
        while (laneIndex == lastLane);

        lastLane = laneIndex;

        Vector3 spawnPos =
            new Vector3(
                spawnX,
                lanes[laneIndex],
                0f);

        Instantiate(
            minePrefab,
            spawnPos,
            Quaternion.identity);
    }
}