using UnityEngine;

public class BoatController : MonoBehaviour
{
    // ==============================
    // MOVIMIENTO
    // ==============================
    [Header("Movimiento")]
    public float speed = 6f;          // Velocidad del barco
    public float minX = -2.8f;        // Límite izquierdo
    public float maxX = 2.8f;         // Límite derecho

    private float targetX;            // Posición objetivo en X

    // ==============================
    // INCLINACIÓN (EFECTO NATURAL)
    // ==============================
    [Header("Inclinación")]
    public float tiltAmount = 15f;    // Cuánto se inclina el barco
    public float tiltSpeed = 5f;      // Qué tan rápido rota

    void Start()
    {
        // Guardamos la posición inicial del barco
        targetX = transform.position.x;
    }

    void Update()
    {
        // ==============================
        // 1. LEER INPUT
        // ==============================
        float input = 0f;

        // Input de teclado (para PC)
        input = Input.GetAxis("Horizontal");

        // Input táctil (para Android)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Si toca lado izquierdo → mover izquierda
            if (touch.position.x < Screen.width / 2)
                input = -1f;
            else
                input = 1f;
        }

        // ==============================
        // 2. CALCULAR NUEVA POSICIÓN
        // ==============================
        targetX += input * speed * Time.deltaTime;

        // Limitar para que no salga de pantalla
        targetX = Mathf.Clamp(targetX, minX, maxX);

        // Movimiento suave hacia la posición objetivo
        float newX = Mathf.Lerp(transform.position.x, targetX, 10f * Time.deltaTime);

        // Aplicar posición (solo en X)
        transform.position = new Vector3(newX, transform.position.y, 0f);

        // ==============================
        // 3. ROTACIÓN (INCLINACIÓN DEL BARCO)
        // ==============================

        // Calculamos hacia dónde debería inclinarse
        float targetRotation = -input * tiltAmount;

        // Obtenemos la rotación actual en Z
        float currentRotation = transform.rotation.eulerAngles.z;

        // Evita saltos raros entre 0° y 360°
        if (currentRotation > 180)
            currentRotation -= 360;

        // Interpolamos suavemente la rotación
        float newRotation = Mathf.Lerp(currentRotation, targetRotation, tiltSpeed * Time.deltaTime);

        // Aplicamos la rotación
        transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
    }
}