using UnityEngine;
using DigitalRubyShared; 

public class ObjectPanController : MonoBehaviour
{
    private PanGestureRecognizer panGesture;
    private Vector3 initialPosition;
    private bool hasStartedMoving = false;

    private void Start()
    {
        panGesture = new PanGestureRecognizer
        {
            ThresholdUnits = 0.2f,
            MinimumNumberOfTouchesToTrack = 1,
            MaximumNumberOfTouchesToTrack = 1
        };

        panGesture.StateUpdated += PanGesture_StateUpdated;

        FingersScript.Instance.AddGesture(panGesture);

        initialPosition = transform.position;
    }

    private void PanGesture_StateUpdated(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Began)
        {
            hasStartedMoving = false; 
            return;
        }

        if (gesture.State == GestureRecognizerState.Executing)
        {
            if (!hasStartedMoving && (Mathf.Abs(panGesture.DeltaX) < 10f && Mathf.Abs(panGesture.DeltaY) < 10f))
            {
                return; 
            }

            hasStartedMoving = true;

            Vector3 screenDelta = new Vector3(panGesture.DeltaX, 0, panGesture.DeltaY);
            Vector3 worldDelta = Camera.main.transform.TransformDirection(screenDelta) * 0.01f;

            transform.position = Vector3.Lerp(transform.position,
                new Vector3(transform.position.x + worldDelta.x,
                            transform.position.y,
                            transform.position.z + worldDelta.z),
                Time.deltaTime * 10f);
        }
    }
}
