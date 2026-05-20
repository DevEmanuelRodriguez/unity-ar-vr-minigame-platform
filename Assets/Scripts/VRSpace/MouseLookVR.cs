using UnityEngine;

public class MouseLookVR : MonoBehaviour
{
#if UNITY_EDITOR

    public float sensitivity = 100f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState =
            CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX =
            Input.GetAxis("Mouse X") *
            sensitivity *
            Time.deltaTime;

        float mouseY =
            Input.GetAxis("Mouse Y") *
            sensitivity *
            Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation =
            Mathf.Clamp(
                xRotation,
                -80f,
                80f
            );

        transform.localRotation =
            Quaternion.Euler(
                xRotation,
                yRotation,
                0f
            );
    }

#endif
}