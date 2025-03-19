using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AlertPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [SerializeField] private GameObject alertUI;

    public void Show(string titleMessage, string descriptionMessage, bool isYesButtonVisible, string yesButtonMessage, 
        bool isNoButtonVisible, string noButtonMessage)
    {
        alertUI.SetActive(true);
        title.text = titleMessage;
        description.text = descriptionMessage;
        yesButton.gameObject.SetActive(isYesButtonVisible);
        yesButton.GetComponentInChildren<TextMeshProUGUI>().text = yesButtonMessage;
        noButton.gameObject.SetActive(isNoButtonVisible);
        noButton.GetComponentInChildren<TextMeshProUGUI>().text = noButtonMessage;
    }

    public void Hide() 
    {
        alertUI.SetActive(false);
    }
}
