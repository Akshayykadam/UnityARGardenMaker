using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlantPlacementManager : MonoBehaviour
{
    public GameObject[] Plants;
    public ARSessionOrigin sessionOrigin;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planManager;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    private void Update()
    {
        Debug.Log("touchCount :: " + Input.touchCount);
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            bool Collision = raycastManager.Raycast(Input.mousePosition, raycastHits, TrackableType.PlaneWithinPolygon);

            if (Collision)
            {
                GameObject _object = Instantiate(Plants[Random.Range(0, Plants.Length - 1)]);
                _object.transform.position = raycastHits[0].pose.position;

                foreach (var plans in planManager.trackables)
                {
                    plans.gameObject.SetActive(false);
                }
                planManager.enabled = false;
            }
        }
    }
}
