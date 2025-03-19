using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public AlertPopup alertPopup;

    public LoginPanel loginPanel;
    public StructuralPanel structuralPanel;

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
}
