using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ARMenuController : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Button homeButton;

    void Start()
    {
        menuButton.onClick.AddListener(OpenMenuPanel);
        homeButton.onClick.AddListener(OpenHomePanel);
    }

    private void OpenHomePanel()
    {
        SceneManager.LoadScene(ScenesInBuild.menuScene);
    }

    private void OpenMenuPanel()
    {
        ARModeManager.Instance.sidePanel.ShowPanel();
    }
}
