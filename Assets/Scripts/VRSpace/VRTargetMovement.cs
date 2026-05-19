using UnityEngine;

public class VRTargetMovement : MonoBehaviour
{
    public float moveSpeed = 2.5f;

    private Transform player;
    private VRGameScore gameScore;

    // distancia para perder
    public float hitDistance = 0.5f;

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
            FindObjectOfType
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

        // comprobar distancia
        float distance =
            Vector3.Distance(
                transform.position,
                player.position
            );

        // perder si llega al jugador
        if (distance <= hitDistance)
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
    }
}