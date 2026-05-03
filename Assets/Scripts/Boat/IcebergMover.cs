using UnityEngine;

public class IcebergMover : MonoBehaviour
{
    public float speed = 4f; // Velocidad a la que cae el iceberg

    void Update()
    {
        // Mueve el iceberg hacia abajo cada frame
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Si sale por debajo de la pantalla, se destruye
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}
