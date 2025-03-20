using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SidePanel : MonoBehaviour
{
    [SerializeField] private Button closButton;
    [SerializeField] private Button roationButton;
    [SerializeField] private Button positionButton;
    [SerializeField] private Button generateBomButton;
    [SerializeField] private Button logoutButton;

    [SerializeField] private GameObject sidePanel;

    [SerializeField] private bool isARMode;

    private void Start()
    {
        if (isARMode)
        {
            roationButton.onClick.AddListener(EnableRoation);
            positionButton.onClick.AddListener(EnablePositioning);
            generateBomButton.onClick.AddListener(GenerateBOM);
        }
        
        logoutButton.onClick.AddListener(Logout);
        closButton.onClick.AddListener(HidePanel);
    }

    private void OnEnable()
    {
        isARMode = SceneManager.GetActiveScene().name.Equals(ScenesInBuild.ARScene);
    }

    private void Logout() 
    {
        if (isARMode)
        {
            // need to implement ARMode Logout
        }
        else 
        {
            UIManager.Instance.DisablePanels();
            HidePanel();
            UIManager.Instance.loginPanel.gameObject.SetActive(true);
        }
    }


    public void HidePanel() 
    {
        sidePanel.SetActive(false);
    }

    public void ShowPanel() 
    {
        sidePanel.SetActive(true);
    }

    private void EnableRoation()
    {
       // Enable the placed object Rotation
    }

    private void EnablePositioning()
    {
       // Enable position changes of the placed object
    }

    private void GenerateBOM()
    {
        // Enable position changes of the placed object
    }

}
