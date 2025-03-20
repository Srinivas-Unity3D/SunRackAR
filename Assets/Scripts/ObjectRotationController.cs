using UnityEngine;
using DigitalRubyShared; // Import Fingers Lite API

public class ObjectRotationController : MonoBehaviour
{
    private RotateGestureRecognizer rotateGesture;
    private bool hasStartedRotating = false; 

    private void Start()
    {
        rotateGesture = new RotateGestureRecognizer();
        rotateGesture.StateUpdated += RotateGesture_StateUpdated;

        FingersScript.Instance.AddGesture(rotateGesture);
    }

    private void RotateGesture_StateUpdated(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Began)
        {
            hasStartedRotating = false; 
            return;
        }

        if (gesture.State == GestureRecognizerState.Executing)
        {
            if (!hasStartedRotating && Mathf.Abs(rotateGesture.RotationDegreesDelta) < 2f)
            {
                return; 
            }

            hasStartedRotating = true; 

            transform.Rotate(Vector3.up, rotateGesture.RotationDegreesDelta, Space.World);
        }
    }
}
