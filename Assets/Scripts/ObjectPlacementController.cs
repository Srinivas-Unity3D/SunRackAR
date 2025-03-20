using UnityEngine;
using Vuforia;

public class ObjectPlacementController : MonoBehaviour
{
    public PlaneFinderBehaviour planeFinder;
    public PlaneFinderUIController planeFinderUIController;
    private bool isPlaced = false;            

    void Start()
    {
        planeFinder.OnInteractiveHitTest.AddListener(OnPlaneHit);
    }

    void OnPlaneHit(HitTestResult result)
    {
        if (!isPlaced) 
        {
            transform.position = result.Position;

            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0; 
            transform.rotation = Quaternion.LookRotation(cameraForward);

            isPlaced = true;

            planeFinder.enabled = false;

            planeFinderUIController.DisableMessageBox();
            if (planeFinder.PlaneIndicator != null)
            {
                planeFinder.PlaneIndicator.SetActive(false);
            }
        }
    }

    public void ResetPlacement()
    {
        isPlaced = false;

        planeFinder.enabled = true;
        planeFinderUIController.ResetMessage();

        if (planeFinder.PlaneIndicator != null)
        {
            planeFinder.PlaneIndicator.SetActive(true);
        }
    }
}
