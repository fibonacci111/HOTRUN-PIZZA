using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pause;
    public Transform player;


    public void OnButtonClicResume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void TeleportClicCheckpoint()
    {
        Checkpoint.TeleportToLastCheckpoint(player.transform);
        pause.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void MenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
