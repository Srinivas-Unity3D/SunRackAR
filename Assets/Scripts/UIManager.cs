using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public AlertPopup alertPopup;

    public LoginPanel loginPanel;
    public StructuralPanel structuralPanel;
    public SidePanel sidePanel;

    public UserProfileData userPrfileData;

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void DisablePanels() 
    {
        loginPanel.gameObject.SetActive(false);
        structuralPanel.gameObject.SetActive(false);
        sidePanel.HidePanel();
        // also add upcoming panels
    }
}
