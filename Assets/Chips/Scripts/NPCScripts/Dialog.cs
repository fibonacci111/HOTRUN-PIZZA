using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] GameObject windowDialog;
    [SerializeField] TextMeshProUGUI textDialog;
    [SerializeField] Button button;
    [SerializeField] bool deleteDialogu = false; 
   
    bool look;
    public string[] message;
    private int numberDialog = 0;
    [SerializeField] GameObject DeleteDialogue;
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.Confined;
            look = true;
            
            CameraMoveController.instance.speed = 0;
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
        
    }

    public void NextDialog()
    {
        numberDialog++;
        textDialog.text = message[numberDialog];
        if (numberDialog == message.Length - 1)
        {
            button.gameObject.SetActive(false);
            look = false;
           windowDialog.SetActive(false);
        numberDialog = 0;
        CameraMoveController.instance.speed = CameraMoveController.instance.normalSpeed;
        button.onClick.RemoveAllListeners();
            if (deleteDialogu)
            {
                DeleteDialogue.SetActive(false);
            }
           
            CameraMoveController.instance.speed = CameraMoveController.instance.normalSpeed;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

