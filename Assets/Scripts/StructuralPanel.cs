using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StructuralPanel : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private TMP_Dropdown heightDropDown;
    [SerializeField] private TMP_Dropdown panelsDropDown;
    [SerializeField] private Button arMode;
    [SerializeField] private Button mapMode;


    void Start()
    {
        menuButton.onClick.AddListener(ShowSidePanel);
    }

    private void ShowSidePanel() 
    {
        UIManager.Instance.sidePanel.ShowPanel();
    }
}
