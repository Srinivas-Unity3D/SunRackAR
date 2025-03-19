using UnityEngine;
using UnityEngine.UI;

public class SidePanel : MonoBehaviour
{
    [SerializeField] private Button closButton;
    [SerializeField] private Button roationButton;
    [SerializeField] private Button positionButton;
    [SerializeField] private Button generateBomButton;
    [SerializeField] private Button logoutButton;

    [SerializeField] private GameObject sidePanel;

    private void Start()
    {
        closButton.onClick.AddListener(HidePanel);
        logoutButton.onClick.AddListener(Logout);
    }

    private void Logout() 
    {
        // if required we can restart the scene or load menu scene
        UIManager.Instance.DisablePanels();
        HidePanel();
        UIManager.Instance.loginPanel.gameObject.SetActive(true);
    }


    public void HidePanel() 
    {
        sidePanel.SetActive(false);
    }

    public void ShowPanel() 
    {
        sidePanel.SetActive(true);
    }
}
