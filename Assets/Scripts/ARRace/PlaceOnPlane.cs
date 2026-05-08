using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    public GameObject prefab;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject spawnedObject;

    void Awake()
    {
        raycastManager = FindFirstObjectByType<ARRaycastManager>();
    }

    void Update()
    {
        if (spawnedObject != null) return;

        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            spawnedObject = Instantiate(prefab, hitPose.position, hitPose.rotation);

            //  EMPEZAR PARTIDA
            ARRaceGameManager gameManager = FindFirstObjectByType<ARRaceGameManager>();

            if (gameManager != null)
            {
                gameManager.StartGame();
            }
        }
    }
}