using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NainMenu : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu.SetActive(true);
          Cursor.lockState = CursorLockMode.Confined;
        }
    }
    public void MaiMenu() {
        SceneManager.LoadScene(0);
    }
    public void Load()
    {
        MainMenu.SetActive(false);
        Cursor.lockState= CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    
}
