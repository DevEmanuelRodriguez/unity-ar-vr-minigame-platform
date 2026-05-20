using UnityEngine;

public class VRTargetMovement : MonoBehaviour
{
    public float moveSpeed = 2.5f;

    // distancia base de golpe
    public float baseHitDistance = 0.25f;

    private Transform player;
    private VRGameScore gameScore;

    void Start()
    {
        GameObject playerObject =
            GameObject.Find("VRPlayer");

        if (playerObject != null)
        {
            player =
                playerObject.transform;
        }

        gameScore =
            FindFirstObjectByType
            <VRGameScore>();
    }

    void Update()
    {
        if (player == null)
            return;

        // mover hacia jugador
        transform.position =
            Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed *
                Time.deltaTime
            );

        float distance =
            Vector3.Distance(
                transform.position,
                player.position
            );

        // hit depende del tamaño
        float scaleFactor =
            transform.localScale.x;

        float realHitDistance =
            baseHitDistance *
            scaleFactor;

        // GAME OVER
        if (distance <= realHitDistance)
        {
            Debug.Log(
                "PLAYER HIT"
            );

            if (gameScore != null)
            {
                gameScore.GameOver();
            }

            Destroy(gameObject);
        }

        // destruir si queda detrás
        Vector3 directionToTarget =
            transform.position -
            player.position;

        float dot =
            Vector3.Dot(
                player.forward,
                directionToTarget.normalized
            );

        if (dot < -0.3f)
        {
            Destroy(gameObject);
        }
    }
}