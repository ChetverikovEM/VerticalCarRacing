using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;

    public void OnButton()
    {
        gameObject.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
