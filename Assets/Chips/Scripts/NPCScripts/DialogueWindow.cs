using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class DialogueWindow : MonoBehaviour
{
    [SerializeField] GameObject windowDialog;
    [SerializeField] TextMeshProUGUI textDialog;
    [SerializeField] Button button;


    public string[] message;
    private int numberDialog = 0;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            if (numberDialog == message.Length - 1)
            {
                button.gameObject.SetActive(false);

            }
            else
            {
                button.gameObject.SetActive(true);
                button.onClick.AddListener(NextDialog);
            }

            windowDialog.SetActive(true);
            textDialog.text = message[numberDialog];
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        windowDialog.SetActive(false);
        numberDialog = 0;
        button.onClick.RemoveAllListeners();
    }

    public void NextDialog()
    {
        numberDialog++;
        textDialog.text = message[numberDialog];
        if (numberDialog == message.Length - 1)
        {
            button.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
