using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 1.5f;

    void Update()
    {
        // avanzar en dirección propia
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}