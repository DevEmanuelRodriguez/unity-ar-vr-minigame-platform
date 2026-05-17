using UnityEngine;

public class VRTargetMovement : MonoBehaviour
{
    public float moveSpeed = 2.5f;

    private Transform player;
    private VRGameScore gameScore;

    void Start()
    {
        GameObject playerObject =
            GameObject.Find("VRPlayer");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        gameScore =
            FindObjectOfType<VRGameScore>();
    }

    void Update()
    {
        if (player == null)
            return;

        transform.position =
            Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER HIT");

            if (gameScore != null)
            {
                gameScore.GameOver();
            }

            Destroy(gameObject);
        }
    }
}