using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] private GameObject showButton;
    [SerializeField] private GameObject hideButton;
    [SerializeField] private TMP_InputField passwordField;

    private Button currentButton;
    private bool isShow;

    void Start()
    {
        currentButton = GetComponent<Button>();
        currentButton.onClick.AddListener(OnCurrentButtonClick);
    }

    private void OnCurrentButtonClick() 
    {
        isShow = isShow ? false: true;
        ChangeInputFieldContentType(isShow);
        ToggleButtonSprite(isShow);
    }

    private void ToggleButtonSprite(bool isShow) 
    {
       showButton.SetActive(isShow);
       hideButton.SetActive(!isShow);
    }

    private void ChangeInputFieldContentType(bool isShow) 
    {
        passwordField.contentType = isShow ? TMP_InputField.ContentType.Standard : TMP_InputField.ContentType.Password;
        passwordField.ForceLabelUpdate();
    }
}
