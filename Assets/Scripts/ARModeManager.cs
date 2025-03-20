using UnityEngine;
using TMPro;

public class ARModeManager : MonoBehaviour
{
    public static ARModeManager Instance;

    public SidePanel sidePanel;

    public GlobalVariables globalVariables;

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
