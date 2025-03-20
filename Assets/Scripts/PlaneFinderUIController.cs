using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using TMPro;

public class PlaneFinderUIController : MonoBehaviour
{
    public PlaneFinderBehaviour planeFinder;  
    public GameObject messagePanel;           
    public TextMeshProUGUI messageText;                  

    private bool isFloorDetected = false;    

    void Start()
    {
        planeFinder.OnAutomaticHitTest.AddListener(OnPlaneDetected);
        ShowMessage("Please point your camera towards the floor");
    }

    void OnPlaneDetected(HitTestResult result)
    {
        if (!isFloorDetected)
        {
            isFloorDetected = true;
            ShowMessage("Tap to place the object");
        }
    }

    public void ShowMessage(string message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            messagePanel.SetActive(true);
            messageText.text = message;
        }
        else
        {
            messagePanel.SetActive(false);
        }
    }

    public void DisableMessageBox()
    {
        messagePanel.SetActive(false);
    }

    public void ResetMessage()
    {
        isFloorDetected = false;
        ShowMessage("Please point your camera towards the floor");
    }
}
