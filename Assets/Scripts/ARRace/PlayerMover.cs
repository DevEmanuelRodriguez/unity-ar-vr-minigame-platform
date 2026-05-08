using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float limit = 0.5f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        float screenMiddle = Screen.width / 2f;

        float moveInput = 0f;

        if (touch.position.x < screenMiddle)
        {
            moveInput = -1f;
        }
        else
        {
            moveInput = 1f;
        }

        // mover relativo al player
        Vector3 lateralMove =
            transform.right *
            moveInput *
            moveSpeed *
            Time.deltaTime;

        Vector3 targetPosition = transform.position + lateralMove;

        // calcular desplazamiento lateral respecto posición inicial
        Vector3 offset = targetPosition - startPosition;

        float lateralAmount = Vector3.Dot(offset, transform.right);

        // limitar movimiento lateral
        lateralAmount = Mathf.Clamp(lateralAmount, -limit, limit);

        targetPosition =
            startPosition +
            transform.right * lateralAmount;

        transform.position = targetPosition;
    }
}