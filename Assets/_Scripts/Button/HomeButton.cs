using UnityEngine;

public class HomeButtonSettings : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;

    public void OnButton()
    {
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
