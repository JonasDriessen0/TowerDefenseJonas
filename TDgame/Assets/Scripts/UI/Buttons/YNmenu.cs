using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YNmenu : MonoBehaviour
{
    public GameObject menu;

    public void ShowMenu()
    {
        menu.SetActive(true);
    }
    public void NoMenu()
    {
        menu.SetActive(false);
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
