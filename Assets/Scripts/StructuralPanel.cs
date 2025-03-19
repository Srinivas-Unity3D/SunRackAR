using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class StructuralPanel : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private TMP_Dropdown heightDropDown;
    [SerializeField] private TMP_Dropdown panelsDropDown;
    [SerializeField] private Button arMode;
    [SerializeField] private Button mapMode;

    [SerializeField] private TextMeshProUGUI warningMessage;


    [SerializeField] private int structureHeightValue;
    [SerializeField] private int structurePanelsValue;


    void Start()
    {
        OnHeightSelection();
        OnPanelSelection();

        menuButton.onClick.AddListener(ShowSidePanel);
        arMode.onClick.AddListener(OpenARMode);
    }

    private void OpenARMode() 
    {
        if (structureHeightValue <= 0) 
        {
            StartCoroutine(ShowWarningMessage(2f, "Please select structure height"));
            return;
        }

        if (structurePanelsValue <= 0)
        {
            StartCoroutine(ShowWarningMessage(2f, "Please select structure panels"));
            return;
        }

        SceneManager.LoadScene(ScenesInBuild.ARScene);
    }

    private void OnPanelSelection()
    {
        OnDropdownSelection(panelsDropDown, (value) => structurePanelsValue = value);
    }

    private void OnHeightSelection() 
    {
        OnDropdownSelection(heightDropDown, (value) => structureHeightValue = value);
    }

    private void OnDropdownSelection(TMP_Dropdown dropdown, Action<int> onValueCahnge) 
    {
        dropdown.onValueChanged.AddListener((value) =>
        {
            onValueCahnge?.Invoke(value);
        });
    }

    private void ShowSidePanel() 
    {
        UIManager.Instance.sidePanel.ShowPanel();
    }

    private IEnumerator ShowWarningMessage(float timeDelay, string message)
    {
        warningMessage.text = $"Warning: {message}";
        yield return new WaitForSeconds(timeDelay);
        warningMessage.text = string.Empty;
    }
}
