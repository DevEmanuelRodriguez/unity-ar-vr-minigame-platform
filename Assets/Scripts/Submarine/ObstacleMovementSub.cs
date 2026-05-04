using UnityEngine;

public class ObstacleMovementSub : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 1.5f;

    [Header("Destroy Settings")]
    [SerializeField] private float destroyXPosition = -10f;
    [SerializeField] private float startXPosition = 8f;

    void Update()
    {
        Move();
        CheckIfOffScreen();
    }

    void Move()
    {
        // Movimiento constante hacia la izquierda
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void CheckIfOffScreen()
    {
        // Destruye el objeto cuando sale de la pantalla
        if (transform.position.x < destroyXPosition)
        {
            Vector3 pos = transform.position;
            pos.x = startXPosition;
            transform.position = pos;
        }
    }
}
