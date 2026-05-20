using UnityEngine;

public class VRGazeDetector : MonoBehaviour
{
    public float gazeTime = 1f;

    private float timer = 0f;

    private AudioSource destroySound;

    void Start()
    {
        destroySound =
            GetComponent<AudioSource>();
    }

    void Update()
    {
        Ray ray =
            new Ray(
                transform.position,
                transform.forward
            );

        RaycastHit hit;

        Debug.DrawRay(
            transform.position,
            transform.forward * 20f,
            Color.red
        );

        if (Physics.Raycast(
    ray,
    out hit,
    20f
))
        {
            Debug.Log(
                "LOOKING AT: " +
                hit.collider.name
            );

            if (hit.collider
                .CompareTag("VRTarget"))
            {
                timer +=
                    Time.deltaTime;

                if (timer >= gazeTime)
                {
                    Debug.Log(
                        "DESTROYED: " +
                        hit.collider.name
                    );

                    if (destroySound != null)
                    {
                        destroySound.Play();
                    }

                    Destroy(
                        hit.collider.gameObject
                    );

                    timer = 0f;
                }
            }
            else
            {
                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }
    }
}