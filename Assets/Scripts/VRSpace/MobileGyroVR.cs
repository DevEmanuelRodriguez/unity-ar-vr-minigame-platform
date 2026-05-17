using UnityEngine;

public class MobileGyroVR : MonoBehaviour
{
    private Gyroscope gyro;

    void Start()
    {
        // Forzar horizontal VR
        Screen.orientation =
            ScreenOrientation.LandscapeLeft;

        // bloquear rotaciones raras
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeRight = false;

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    void Update()
    {
        if (gyro != null)
        {
            Quaternion deviceRotation =
                gyro.attitude;

            transform.localRotation =
                Quaternion.Euler(90, 0, 0) *
                new Quaternion(
                    -deviceRotation.x,
                    -deviceRotation.y,
                    deviceRotation.z,
                    deviceRotation.w
                );
        }
    }
}